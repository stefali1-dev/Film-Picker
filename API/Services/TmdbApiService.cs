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

    private void SetClientOptions(string options)
    {
        _options = new RestClientOptions("https://api.themoviedb.org/3/" + options);
        _client = new RestClient(_options);
    }

    private List<MovieDto> GetMovieList(string jsonResponse)
    {
        if (jsonResponse == null)
            return null;
        var responseObject = JsonSerializer.Deserialize<MovieSearchDto>(jsonResponse);
        return responseObject.Results.ToList();
    }

    public async Task<ActionResult<IEnumerable<MovieDto>>> SearchMovieAsync(string movieName)
    {
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(movieName);

        // Convert the byte array back to a UTF-8 encoded string
        string utf8EncodedMovieName = Encoding.UTF8.GetString(utf8Bytes);
        
        SetClientOptions($"search/movie?query={utf8EncodedMovieName}");
        var response = await _client.GetAsync(_request);
        var movieList = GetMovieList(response.Content);
       
        // Return the first 5 movies
        return movieList.Take(5).ToList();
    }

    public async Task<IEnumerable<MovieDto>> GetRecommendedMoviesAsync(int movieId, List<int> favoriteMovieIds)
    {
        SetClientOptions($"movie/{movieId}/recommendations");
        var response = await _client.GetAsync(_request);
        var movieList = GetMovieList(response.Content);
        movieList.RemoveAll(item => favoriteMovieIds.Contains(item.Id));
        
        // Return the first 12 movies
        return movieList.Take(12).ToList();
    }

    public async Task<ActionResult<MovieDto>> GetMovieDetailsAsync(int movieId)
    {
        // movie/27205
        SetClientOptions($"movie/{movieId}");
        var responseJson = (await _client.GetAsync(_request)).Content;
        
        if (responseJson == null) // return not found
            return new NotFoundResult();
        var movieResponseObject = JsonSerializer.Deserialize<MovieDto>(responseJson);

        return movieResponseObject;
    }
}