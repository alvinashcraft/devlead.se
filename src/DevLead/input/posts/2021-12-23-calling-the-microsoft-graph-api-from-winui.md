---
title: Calling the Microsoft Graph API from WinUI
author: Alvin A.
type: post
date: 2021-12-23T09:00:00+00:00
url: /2021/12/23/calling-the-microsoft-graph-api-from-winui/
categories:
  - Development
  - dotnet
  - how-to
tags:
  - .net
  - azure
  - 'c#'
  - dependency injection
  - graph api
  - mvvm
  - windows app sdk
  - winui

---
> This post is part of the <a href="https://www.csadvent.christmas/" target="_blank" rel="noopener">C# Advent Calendar 2021</a>. Be sure to check out all the other great posts there this month!

The <a href="https://developer.microsoft.com/en-us/graph/" target="_blank" rel="noopener">Microsoft Graph</a> allows developers to query information from Microsoft 365, including data about users, mail, Teams, OneDrive, notes, and lots more. I’ve been exploring the <a href="https://docs.microsoft.com/en-us/graph/azuread-users-concept-overview" target="_blank" rel="noopener">user</a> and <a href="https://docs.microsoft.com/en-us/graph/teams-concept-overview" target="_blank" rel="noopener">teamwork</a> APIs recently, but in this introduction we will explore how to authenticate and retrieve some user attributes for the authenticated user account.

The sample is a WinUI application created with the <a href="https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/#:~:text=Get%20started%20with%20the%20Windows%20App%20SDK%20Set,to%20use%20the%20Windows%20App%20SDK%20in%20an" target="_blank" rel="noopener">Windows App SDK</a>, C#, .NET, and the .NET Graph SDK that will authenticate a Microsoft Account and display the name & email address for the authenticated user.

Start by installing the Visual Studio 2022 workload for **.NET Desktop Development** and check the option for the **Windows App SDK C# Templates** to add the project templates to your IDE. Complete instructions for getting started with the latest SDK can be found <a href="https://docs.microsoft.com/en-us/windows/apps/windows-app-sdk/set-up-your-development-environment?tabs=vs-2022" target="_blank" rel="noopener">here</a>.

Next, create a new Blank App, Packaged (WinUI in Desktop) project in Visual Studio. I am using Visual Studio 2022, but 2019 is also supported:

[<img loading="lazy" decoding="async" style="border: 0px currentcolor; margin-right: auto; margin-left: auto; float: none; display: block; background-image: none;" title="winui_graphsdk_01" src="/wp-content/uploads/2021/12/winui_graphsdk_01_thumb.png" alt="winui_graphsdk_01" width="640" height="427" border="0" />][1]

<p align="center">
  <sup>Figure 1 &#8211; Creating a new WinUI project</sup>
</p>

After the project has been created, it’s always a good practice to run it to make sure things are working out of the box. Now we will add the NuGet packages needed to build our WinUI Graph app:

  * **Azure.Identity** – Used for interactive MSAL authentication
  * **Microsoft.Extensions.DependencyInjection** – Our DI container of choice for this app
  * **Microsoft.Graph** – The .NET Graph SDK package
  * **Microsoft.Toolkit.Mvvm** – A lightweight, open source MVVM framework

[<img loading="lazy" decoding="async" style="border: 0px currentcolor; margin-right: auto; margin-left: auto; float: none; display: block; background-image: none;" title="winui_graphsdk_02" src="/wp-content/uploads/2021/12/winui_graphsdk_02_thumb.png" alt="winui_graphsdk_02" width="640" height="344" border="0" />][2]

<p align="center">
  <sup>Figure 2 – Installing the Microsoft.Toolkit.Mvvm package</sup>
</p>

Install the latest stable version of each of these packages and build the project again. We’re going to start building the app by creating a <span style="font-family: Consolas;">GraphService</span> class and an <span style="font-family: Consolas;">IGraphService</span> interface with one method, <span style="font-family: Consolas;">GetMyDetailsAsync()</span>.

<pre><span style="font-family: Consolas; font-size: small;">public interface IGraphService
{
     Task&lt;User&gt; GetMyDetailsAsync();
}</span></pre>

The method will return a Task of Microsoft.Graph.User. We’ll get to the implementation in a moment, but first we will create an <span style="font-family: Consolas;">Initialize()</span> method that will be called in the constructor. This is where the authentication code is executed.

<pre><span style="font-family: Consolas; font-size: small;">private readonly string[] _scopes = new[] { "User.Read" };
private const string TenantId = "&lt;your tenant id here&gt;";
private const string ClientId = "&lt;your client id here&gt;";
private GraphServiceClient _client;</span>

<span style="font-family: Consolas; font-size: small;">public GraphService()
{
     Initialize();
}</span>

<span style="font-family: Consolas; font-size: small;">private void Initialize()
{
     var options = new InteractiveBrowserCredentialOptions
     {
         TenantId = TenantId,
         ClientId = ClientId,
         AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
         RedirectUri = new Uri("</span><a href="http://localhost&quot;)"><span style="font-family: Consolas; font-size: small;">http://localhost")</span></a><span style="font-family: Consolas; font-size: small;">,
     };</span>

<span style="font-family: Consolas; font-size: small;">    var interactiveCredential = new InteractiveBrowserCredential(options);</span>

<span style="font-family: Consolas; font-size: small;">    _client = new GraphServiceClient(interactiveCredential, _scopes);
}</span></pre>

Using a <span style="font-family: Consolas;">TenantId</span> in the authentication is only necessary if you want to restrict authentication to a single tenant. To read more about using Azure.Identity and MSAL, check out the docs <a href="https://docs.microsoft.com/en-us/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet" target="_blank" rel="noopener">here</a>. The “User.Read” scope is required to access Graph data for the User object. You can read a complete list of Graph permissions <a href="https://docs.microsoft.com/en-us/graph/permissions-reference" target="_blank" rel="noopener">here</a>. The other aspect of using these permissions within your application is that you must have an App Registration in Azure with each required scope granted to the app in the registration. Follow <a href="https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-v2-windows-desktop" target="_blank" rel="noopener">these steps</a> (_under Option 2_) to add your App Registration to your Azure account in the portal. This is where you will find your <span style="font-family: Consolas;">ClientId</span> to enter above. Desktop applications will always use “http://localhost” as the <span style="font-family: Consolas;">RedirectUri</span>.

Now we’re ready to create the implementation to get our <span style="font-family: Consolas;">User</span> object.

<pre><span style="font-family: Consolas; font-size: small;">public async Task&lt;User&gt; GetMyDetailsAsync()
{
     try
     {
         var user = await _client.Me.Request().GetAsync();
         return user;
     }
     catch (Exception ex)
     {
         Console.WriteLine($"Error loading user details: {ex}");
         return null;
     }
}</span></pre>

The code here is straightforward. Using the GraphServiceClient’s fluent API, we’re requesting “Me” to be returned asynchronously. “Me” will always return a User object for the current authenticated user.

Next, create a <span style="font-family: Consolas;">MainViewModel</span> class, inheriting from <span style="font-family: Consolas;">ObservableObject</span> in the MVVM Toolkit. This is the ViewModel for the <span style="font-family: Consolas;">MainWindow</span> that was created as the main window by the WinUI project template. Use this code for MainViewModel.

<pre><span style="font-family: Consolas; font-size: small;">public class MainViewModel : ObservableObject
{
     private string _userName;
     private string _email;</span>

<span style="font-family: Consolas; font-size: small;">    public MainViewModel()
     {
         LoadUserDetailsCommand = new AsyncRelayCommand(LoadUserDetails);
     }</span>

<span style="font-family: Consolas; font-size: small;">    public async Task LoadUserDetails()
     {
         var graphService = Ioc.Default.GetService&lt;IGraphService&gt;();
         var user = await graphService.GetMyDetailsAsync();
         UserName = user.DisplayName;
         Email = user.Mail;
     }</span>

<span style="font-family: Consolas; font-size: small;">    public string UserName
     {
         get { return _userName; }
         set { SetProperty(ref _userName, value, nameof(UserName)); }
     }</span>

<span style="font-family: Consolas; font-size: small;">    public string Email
     {
         get { return _email; }
         set { SetProperty(ref _email, value, nameof(Email)); }
     }</span>

<span style="font-family: Consolas; font-size: small;">    public IAsyncRelayCommand LoadUserDetailsCommand { get; set; }
}</span></pre>

The ViewModel has properties to expose the <span style="font-family: Consolas;">UserName</span> and <span style="font-family: Consolas;">Email</span> that will be retrieved from the <span style="font-family: Consolas;">IGraphService</span> call when <span style="font-family: Consolas;">LoadUserDetails</span> is called and the service is fetched from the DI container. Now let’s set up the DI container in <span style="font-family: Consolas;">App.xaml.cs</span> in the constructor after <span style="font-family: Consolas;">InitializeComponent()</span>.

<pre><span style="font-family: Consolas; font-size: small;">Ioc.Default.ConfigureServices
         (new ServiceCollection()
             .AddSingleton&lt;IGraphService, GraphService&gt;()
             .AddSingleton&lt;MainViewModel&gt;()
             .BuildServiceProvider()
         );</span></pre>

This is registering <span style="font-family: Consolas;">GraphService</span> and <span style="font-family: Consolas;">MainViewModel</span> as singletons in the container. Any call to <span style="font-family: Consolas;">GetService</span> will fetch the same instance. This works for us because we will only have one <span style="font-family: Consolas;">MainWindow</span> and we only want to authenticate once during the lifetime of the application.

It’s finally time to work on the UI. Start by opening <span style="font-family: Consolas;">MainWindow.xaml</span> and use the following markup at the root of the <span style="font-family: Consolas;">Window</span>, replacing the existing controls.

<pre><span style="font-family: Consolas; font-size: small;">&lt;Grid x:Name="MainGrid" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="12"&gt;
     &lt;Grid.RowDefinitions&gt;
         &lt;RowDefinition Height="Auto"/&gt;
         &lt;RowDefinition Height="Auto"/&gt;
         &lt;RowDefinition Height="Auto"/&gt;
         &lt;RowDefinition Height="Auto"/&gt;
         &lt;RowDefinition Height="*"/&gt;
     &lt;/Grid.RowDefinitions&gt;
     
     &lt;TextBlock Text="User name:" Margin="4" Grid.Row="0"/&gt;
     &lt;TextBox Text="{Binding Path=UserName}" Width="200"
              Margin="4" Grid.Row="1" IsReadOnly="True"/&gt;
     &lt;TextBlock Text="Email:" Margin="4" Grid.Row="2"/&gt;
     &lt;TextBox Text="{Binding Path=Email}" Width="200"
              Margin="4" Grid.Row="3" IsReadOnly="True"/&gt;
     &lt;Button Command="{Binding Path=LoadUserDetailsCommand}"
             Margin="4" Content="Load Data" HorizontalAlignment="Right" Grid.Row="4"/&gt;
&lt;/Grid&gt;</span></pre>

We’ve created a parent <span style="font-family: Consolas;">Grid</span> named <span style="font-family: Consolas;">MainGrid</span> with five rows, two <span style="font-family: Consolas;">TextBlock</span> controls and two corresponding <span style="font-family: Consolas;">TextBoxes</span>, and a Load Data <span style="font-family: Consolas;">Button</span>. The two <span style="font-family: Consolas;">TextBox</span> controls have their <span style="font-family: Consolas;">Text</span> properties bound to the <span style="font-family: Consolas;">UserName</span> and <span style="font-family: Consolas;">Email</span> ViewModel properties, and the Button’s <span style="font-family: Consolas;">Command</span> is bound to the <span style="font-family: Consolas;">LoadUserDetailsCommand</span>, which calls <span style="font-family: Consolas;">LoadUserDetails()</span>.

Now let’s get the <span style="font-family: Consolas;">MainViewModel</span> from the DI container in the <span style="font-family: Consolas;">MainWindow.xaml.cs</span> code behind file and set it as the <span style="font-family: Consolas;">MainGrid.DataContext</span>. This will complete our data binding for the window.

<pre><span style="font-family: Consolas; font-size: small;">var viewModel = Ioc.Default.GetService&lt;MainViewModel&gt;();
MainGrid.DataContext = viewModel;</span></pre>

That’s it. You’re ready to run the app. When you click Load Data, you should be prompted to log in to a Microsoft account and accept the scopes required by the app.

<p align="center">
  <a href="/wp-content/uploads/2021/12/winui_graphsdk_04.png"><img loading="lazy" decoding="async" style="border: 0px currentcolor; display: inline; background-image: none;" title="winui_graphsdk_04" src="/wp-content/uploads/2021/12/winui_graphsdk_04_thumb.png" alt="winui_graphsdk_04" width="229" height="300" border="0" /></a> <a href="/wp-content/uploads/2021/12/winui_graphsdk_05.png"><img loading="lazy" decoding="async" style="border: 0px currentcolor; display: inline; background-image: none;" title="winui_graphsdk_05" src="/wp-content/uploads/2021/12/winui_graphsdk_05_thumb.png" alt="winui_graphsdk_05" width="230" height="300" border="0" /></a>
</p>

<p align="center">
  <sup>Figure 3 & 4 – Logging in to access the Graph API</sup>
</p>

Once the login is complete, you should see your username and email address populated in the text fields. We’ve done it! And notice how the WinUI window and controls pick up your Windows theme and other UI appearance without any extra markup or code required. I’m using the dark theme in Windows 11, and my app is as well.

[<img loading="lazy" decoding="async" style="border: 0px currentcolor; margin-right: auto; margin-left: auto; float: none; display: block; background-image: none;" title="winui_graphsdk_06" src="/wp-content/uploads/2021/12/winui_graphsdk_06_thumb.png" alt="winui_graphsdk_06" width="314" height="482" border="0" />][3]

<p align="center">
  <sup>Figure 5 – Displaying the user info in our app</sup>
</p>

You can do so much more with the Graph API, using the .NET SDK or the REST APIs. Be sure to explore the <a href="https://docs.microsoft.com/en-us/graph/" target="_blank" rel="noopener">docs</a> to see what data you might want to leverage in your own apps. You can also test your API calls with the <a href="https://developer.microsoft.com/en-us/graph/graph-explorer" target="_blank" rel="noopener">Microsoft Graph Explorer</a> site. To learn more about WinUI, you can also check out my book from Packt Publishing, <a href="https://www.amazon.com/Learn-WinUI-3-0-application-development/dp/1800208669/?tag=amavin-20" target="_blank" rel="noopener">Learn WinUI 3</a>.

<a href="https://www.amazon.com/Learn-WinUI-3-0-application-development/dp/1800208669/?tag=amavin-20" target="_blank" rel="noopener"><img decoding="async" style="display: inline;" src="/wp-content/uploads/2021/01/learnwinui.jpg" /></a>

Get the source code for <a href="https://github.com/alvinashcraft/winui-graphapi-advent2021" target="_blank" rel="noopener">this WinUI app on GitHub</a> to get started with WinUI and the Graph SDK on your own.

Happy coding and happy holidays!

 [1]: /wp-content/uploads/2021/12/winui_graphsdk_01.png
 [2]: /wp-content/uploads/2021/12/winui_graphsdk_02.png
 [3]: /wp-content/uploads/2021/12/winui_graphsdk_06.png