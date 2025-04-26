<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryItPage._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">TryItPage</h1>
            <p class="lead">This page should be used to test the references made for Assignment 3 of CSE445</p>
            <p>&nbsp;</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">First Required Service - WordFilter</h2>
                <p>
                    This service removes function words and additional words that are not meaningful in the end purpose of this app.</p>
                <p>
                    Input text:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Invoke" />
                </p>
                <p>
                    Result:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </p>
                <p>
                    &nbsp;</p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Second Required Service - ChatGPT API</h2>
                <p>
                    This simply responds to the user in a comforting tone while the elective service runs and diagnoses the user.</p>
                <p>
                    &nbsp;Input Text:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Invoke" />
                </p>
                <p>
                    Result:<asp:Label ID="Label2" runat="server" Text="Output"></asp:Label>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Elected Service - User Diagnosis</h2>
                <p>
                    This service parses the user&#39;s input and uses keywords to diagnose the user&#39;s current mental state. It also keeps a symptom list, calculates severity of the issue, and also keeps a list of the user&#39;s symptoms</p>
                <p>
                    Input Text:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Invoke" />
                </p>
                <p>
                    Diagnosis::<asp:Label ID="Label3" runat="server" Text="Output"></asp:Label>
                </p>
                <p>
                    Severity:
                    <asp:Label ID="Label4" runat="server" Text="Output"></asp:Label>
                </p>
                <p>
                    Symptoms:
                    <asp:Label ID="Label5" runat="server" Text="Output"></asp:Label>
                </p>
                <p>
                    SymptomCount:
                    <asp:Label ID="Label6" runat="server" Text="Output"></asp:Label>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
