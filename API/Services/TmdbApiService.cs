using System.Text;
using System.Text.Json;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace API.Services;

public class TmdbApiService : ITmdbApiService
{
    private RestClientOptions _options;
    private RestClient _client;
    private readonly RestRequest _request;
    
    public TmdbApiService(string bearerToken)
    {
        _request = new RestRequest("");
        _request.AddHeader("accept", "application/json");
        _request.AddHeader("Authorization", bearerToken);

    }

    public async Task<ActionResult<IEnumerable<MovieDto>>> SearchMovieAsync(string movieName)
    {
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(movieName);

        // Convert the byte array back to a UTF-8 encoded string
        string utf8EncodedMovieName = Encoding.UTF8.GetString(utf8Bytes);
        
        SetClientOptions($"search/movie?query={utf8EncodedMovieName}");
        var response = await _client.GetAsync(_request);
        var jsonString = response.Content;

        if (jsonString == null)
            return null;
        
        var responseObject = JsonSerializer.Deserialize<MovieSearchDto>(jsonString);
       
        List<MovieDto> firstFiveMovies = new List<MovieDto>();
        
        // iterate trough responseObject.Results
        int counter = 0;
        foreach (var movie in responseObject.Results)
        {
            firstFiveMovies.Add(movie);
            counter++;
            if (counter == 5)
                break;
        }

        return firstFiveMovies;
    }
    
    private void SetClientOptions(string options)
    {
        _options = new RestClientOptions("https://api.themoviedb.org/3/" + options);
        _client = new RestClient(_options);
    }
}