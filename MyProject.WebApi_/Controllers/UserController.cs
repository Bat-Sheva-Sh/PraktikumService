﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.WebApi_.Models;
using MyProject.Common.DTOs;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.WebApi_.Controllers
{
    [Route("/[controller]")]//api
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            return await _userService.GetListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> Get(string userId)
        {
            return await _userService.GetByTzAsync(userId);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _userService.AddAsync(model.Name, model.UserId, model.DateOfBirth, model.FamilyName, model.Kind, model.Hmo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] UserModel model)//insert-add
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return await _userService.UpdateAsync(id, model.Name, model.UserId, model.DateOfBirth, model.FamilyName, model.Kind, model.Hmo);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string userId)
        {
            await _userService.DeleteAsync(userId);
            return NoContent();
        }

    }
}

