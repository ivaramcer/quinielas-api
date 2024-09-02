using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuinielasApi.Models.DatabaseContext;
using QuinielasApi.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using QuinielasApi.Models.DTOs;
using AutoMapper;
using NuGet.Protocol.Core.Types;
using QuinielasApi.IRepository.Configuration;
using QuinielasApi.JWTConfiguration;

namespace QuinielasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class RolesController : ControllerBase
    {
        private readonly JWTUtils _jwtUtils;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public RolesController(IRepositoryWrapper repository, JWTUtils jwtUtils, IMapper mapper)
        {
            _jwtUtils = jwtUtils;
            _repository = repository;
            _mapper = mapper;


        }

        
    }
}
