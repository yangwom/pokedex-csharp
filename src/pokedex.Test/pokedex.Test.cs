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
                new PokemonCatched() { Id = 0, Name = "Bulbasaur" },
                new PokemonCatched() { Id = 1, Name = "Pikachu" },
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
            throw new NotImplementedException();
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnsCreatedResponse()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void Add_ValidPokemonPassed_ReturnedResponseHasCreatedItem()
        {
            throw new NotImplementedException();
        }

        // Testes PUT
        [Fact]
        public void PutById_ExistingIdPassed_ReturnsOkResult()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void PutById_IdNotFound_ReturnsNotFoundResult()
        {
            throw new NotImplementedException();
        }


        // Testes DELETE
        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsOkResult()
        {
            throw new NotImplementedException();
        }

    }
}