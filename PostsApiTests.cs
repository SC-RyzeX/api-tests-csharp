using System.Net;
using System.Text;
using System.Text.Json;
using Xunit;

public class PostsApiTests
{
    private static readonly HttpClient Client =
        new() { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };

    [Fact]
    public async Task GetPost_ReturnsCorrectPost()
    {
        var response = await Client.GetAsync("/posts/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.Equal(1, doc.RootElement.GetProperty("id").GetInt32());
    }

    [Fact]
    public async Task CreatePost_Returns201()
    {
        var body = new StringContent(
            "{\"title\":\"test\",\"body\":\"hello\",\"userId\":1}",
            Encoding.UTF8, "application/json");

        var response = await Client.PostAsync("/posts", body);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.Equal("test", doc.RootElement.GetProperty("title").GetString());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async Task GetUser_ReturnsRequestedUser(int id)
    {
        var response = await Client.GetAsync($"/users/{id}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.Equal(id, doc.RootElement.GetProperty("id").GetInt32());
    }
}