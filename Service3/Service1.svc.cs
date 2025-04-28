using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Service3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public AnalysisResult AnalyzeInput(string input)
        {
            AnalysisResult analysisResult = new AnalysisResult();
            string[] words = input.Split(' ', '.', ',', '\n');
            List<string> symptomsStated = new List<string>();
            int anxCount = 0;
            int depCount = 0;
            int panCount = 0;
            int suiCount = 0;
            int maxCount = 0;
            string[] anxKey = { "anxious", "nervous", "overwhelmed", "panic", "fear", "worried", "worry", "restless" };
            string[] depKey = { "sad", "hopeless", "tired", "empty", "dark", "down", "guilt", "give", "done", "depressed" };
            string[] panKey = { "chest", "breath", "racing", "heartbeat", "dizzy", "dizzyness" };
            string[] suiKey = { "suicide", "kill", "end", "death" };
            string[] urgKey = { "urgent", "emergency", "critical", "help", "immediate" };
            for (int i = 0; i < words.Length; i++)
            { //loop goes through each input word and if they apply to a diagnosis, it increments the counter of that diagnosis and adds the word to the symptom list
                if (anxKey.Contains(words[i]))
                {
                    anxCount++;
                    symptomsStated.Add("Anxiety: " + words[i]);
                }
                if (depKey.Contains(words[i]))
                {
                    depCount++;
                    symptomsStated.Add("Depression: " + words[i]);
                }
                if (panKey.Contains(words[i]))
                {
                    panCount++;
                    symptomsStated.Add("Panic Attack: " + words[i]);
                }
                if (suiKey.Contains(words[i]))
                {
                    suiCount++;
                    symptomsStated.Add("Suicide: " + words[i]);
                }
            }
            //find diagnosis by which condition is mentioned the most
            if (depCount > 0)
            {
                analysisResult.Diagnosis = "Depression";
                maxCount = depCount;//maxCount stores this so we know if a different diagnosis is mentioned more
            }
            if (anxCount > maxCount)
            {
                analysisResult.Diagnosis = "Anxiety";
                maxCount = anxCount;//maxCount stores this so we know if a different diagnosis is mentioned more
            }
            if (panCount > maxCount)
            {
                analysisResult.Diagnosis = "Panic Attack";
                maxCount = panCount;//maxCount stores this so we know if a different diagnosis is mentioned more
            }
            if (suiCount > maxCount)
            {
                analysisResult.Diagnosis = "Suicide";
                maxCount = suiCount;
            }
            //find severity by the amount of times it is mentioned compared to other diagnosed issues
            int totalCount = depCount + anxCount + panCount + suiCount;
            double diagnosisRatio = 0;
            if (totalCount > 0)
            {
                diagnosisRatio = (double)(maxCount / totalCount);
            }
            //multiply that by number of times diagnosis was mentioned to also add the scale of things mentioned to the calculation
            double severityResult = maxCount * diagnosisRatio;
            if (severityResult >= 10)//severityresult should almost never be this high from 1 message in a conversation. Therefore this is severe
            {
                analysisResult.Severity = "Severe";
            }
            else if (severityResult >= 5)//severityresult shows that the diagnosis was mentioned a lot but not an immense amount. This qualifies as moderate
            {
                analysisResult.Severity = "Moderate";
            }
            else
            {
                analysisResult.Severity = "Mild";
            }
            analysisResult.SymptomCount = totalCount; //add symptomCount to analysisResult
            analysisResult.Symptoms = symptomsStated.ToArray();
            return analysisResult;
        }
    }
}
