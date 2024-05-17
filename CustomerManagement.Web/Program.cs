using CustomerManagement.Business;
using CustomerManagement.Business.Services;
using CustomerManagement.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using System;

var builder = WebApplication.CreateBuilder(args);


//appSettings
var apiSettings = new ApiSettings(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();


builder.Services.AddHttpClient<CustomerService>(client =>
{
    //client.BaseAddress = new Uri("https://localhost:7285/");
    client.BaseAddress = new Uri(apiSettings.ApiBaseUrl);
});

builder.Services.AddTransient<CustomerService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddSingleton<IApiSettings, ApiSettings>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();



app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
