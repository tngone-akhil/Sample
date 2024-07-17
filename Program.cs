using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using bugtracker.models;
using bugtracker.temporaryModels;
using bugtrackerapi.functions;
using Microsoft.VisualBasic;
using MongoDB.Bson.IO;

class Program
{
    // static async Task Main()
    // {
    //    await Process();
    // }

    public static async Task ProcessGet(string api)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5090/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Console App");

        HttpResponseMessage response = await client.GetAsync(api);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine();
            string content = await response.Content.ReadAsStringAsync();
            ShareContent(content);

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($" {await response.Content.ReadAsStringAsync()}");
            Console.WriteLine();
        }
    }

    public static async Task ProcessPost(string api, Object requestBody)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5090/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Console App");

        var jsonRequestBody = JsonSerializer.Serialize(requestBody);
        var contents = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

        BugEdit requestBodys = new BugEdit();
        HttpResponseMessage response = await client.PostAsync(api, contents);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine();
            Console.WriteLine(content);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($" {await response.Content.ReadAsStringAsync()}");
            Console.WriteLine();
        }
    }

    public static async Task ProcessPut(string api, Object? data = null)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5090/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Console App");

        var jsonRequestBody = JsonSerializer.Serialize(data);
        var contents = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");
        var response = await client.PutAsync(api, contents);
        if (response.IsSuccessStatusCode)
        {

            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine();
            Console.WriteLine(content);
            Console.WriteLine();

        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($" {await response.Content.ReadAsStringAsync()}");
            Console.WriteLine();
        }
    }

    public static void ShareContent(string contents)
    {
        DevelperFunction.content = contents;
        QAfunctions.content = contents;
        AdminFunctions.content = contents;
    }
}

