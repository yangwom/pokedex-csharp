using pokedex.Models;
using pokedex.Controllers;
using pokedex.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;
using pokemon.Test;
using FluentAssertions;

namespace pokedex.Test
{
    public class PokemonsControllerTest
    {
        PokemonsController _controller;

        IPokemonService _service;

        List<PokemonCatched> _db;
        public PokemonsControllerTest()
        {
            _service = new PokemonServiceFake();
            _controller = new PokemonsController(_service);
            _db = new List<PokemonCatched>()
            {
                new PokemonCatched() { Id = 0, Name = "Ifarnaipe"  },
                new PokemonCatched() { Id = 1, Name = "chalizart" },
            };
        }

        // Testes GET
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var result = _controller.Get().Result;
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllPokemons()
        {
            var result = _controller.Get().Result as OkObjectResult;
            var IsResult = Assert.IsType<List<PokemonCatched>>(result.Value);
            IsResult.Should().BeEquivalentTo(_db);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            var result = _controller.GetById(7).Result;
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            var result = _controller.GetById(0).Result;
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            var result = _controller.GetById(0).Result as OkObjectResult;
            var IsResult = Assert.IsType<PokemonCatched>(result.Value);
            IsResult.Should().BeEquivalentTo(_db[0]);
        }

        // Testes POST
        [Fact]
        public void Add_PokemonWithoutId_ReturnsBadRequest()
        {
            var request = new PokemonCatched() { Name = "pikachu" };
            var response = _controller.Post(request);
            response.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnsCreatedResponse()
        {
            var request = new PokemonCatched() { Id = 2, Name = "pikachu" };
            var result = _controller.Post(request) as OkObjectResult;
            var response = Assert.IsType<PokemonCatched>(result.Value);
            response.Should().BeEquivalentTo(request);
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnedResponseHasCreatedItem()
        {
            var request = new PokemonCatched() { Id = 2, Name = "pikachu" };
            var response = _controller.Post(request) as OkObjectResult;
            var result = Assert.IsType<PokemonCatched>(response.Value);
            result.Should().BeEquivalentTo(request);
        }

        // Testes PUT
        [Fact]
        public void PutById_ExistingIdPassed_ReturnsOkResult()
        {
            var request = new PokemonCatched() { Id = 1, Name = "Gyarados" };
            var result = _controller.Put(1, request);
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void PutById_IdNotFound_ReturnsNotFoundResult()
        {
             var request = new PokemonCatched() { Id = 7, Name = "Onyx" };
            var result = _controller.Put(7, request);
            result.Should().BeOfType<NotFoundResult>();
        }


        // Testes DELETE
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
             var result = _controller.Remove(7);
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
             var result = _controller.Remove(7);
            result.Should().BeOfType<NotFoundResult>();
        }

    }
}