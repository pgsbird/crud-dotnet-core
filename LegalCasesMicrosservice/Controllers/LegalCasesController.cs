using System;
using System.Collections.Generic;
using AutoMapper;
using LegalCasesMicrosservice.Data;
using LegalCasesMicrosservice.Dtos;
using LegalCasesMicrosservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LegalCasesMicrosservice.Controllers
{
    [Route("api/legalcases")]
    [ApiController]
    public class LegalCasesController:ControllerBase
    {
        private readonly ILegalCaseRepo _repository;
        private IMapper _mapper;

        public LegalCasesController(ILegalCaseRepo repository, IMapper mapper)
        {
            _repository  = repository;
            _mapper = mapper;
        }
        //GET api/legalcases
        [HttpGet]
        public ActionResult<IEnumerable<LegalCaseReadDto>> GetAllLegalCases()
        {
            var legalcaseItens = _repository.GetAllLegalCases();

            return Ok(_mapper.Map<IEnumerable<LegalCaseReadDto>>(legalcaseItens));
        }
        //GET api/legalcases/{id}
        [HttpGet("{id}", Name="GetLegalCaseById")]
        public ActionResult<LegalCaseReadDto> GetLegalCaseById(int id)
        {
            var legalcaseItem = _repository.GetLegalCaseById(id);
            if(legalcaseItem != null){
                return Ok(_mapper.Map<LegalCaseReadDto>(legalcaseItem));
            }
            return NotFound();
        }

         //POST api/LegalCases
        [HttpPost]
        public ActionResult<LegalCaseReadDto> CreateLegalCase(LegalCaseCreateDto LegalCaseCreateDto)
        {            
            var LegalCaseModel = _mapper.Map<LegalCase>(LegalCaseCreateDto);
            LegalCaseModel.RegistrationDate = DateTime.Now;
            _repository.CreateLegalCase(LegalCaseModel);
            _repository.SaveChanges();


            var LegalCaseReadDto = _mapper.Map<LegalCaseReadDto>(LegalCaseModel);
            
            return CreatedAtRoute(nameof(GetLegalCaseById), new { Id = LegalCaseReadDto.LegalCaseId }, LegalCaseReadDto);
        }

        //PUT api/LegalCases/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateLegalCase(int id, LegalCaseUpdateDto LegalCaseUpdateDto)
        {
            var LegalCaseModelFromRepo = _repository.GetLegalCaseById(id);
            if (LegalCaseModelFromRepo == null){
                return NotFound();
            }
            
            _mapper.Map(LegalCaseUpdateDto,LegalCaseModelFromRepo);

            _repository.UpdateLegalCase(LegalCaseModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
            
        }

        //DELETE api/LegalCases/{id}
        [HttpDelete("{id}")]
         public ActionResult LegalCaseDelete(int id)
        {
            var LegalCaseModelFromRepo = _repository.GetLegalCaseById(id);

            if (LegalCaseModelFromRepo == null){
                return NotFound();
            }

            _repository.DeleteLegalCase(LegalCaseModelFromRepo);
            _repository.SaveChanges();
            
            return NoContent();

        }

        //PATCH api/legalcase/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialLegalCaseUpdate(int id, JsonPatchDocument<LegalCaseUpdateDto> patchDoc)
        {
            var LegalCaseModelFromRepo = _repository.GetLegalCaseById(id);

            if (LegalCaseModelFromRepo == null){
                return NotFound();
            }
            var legalcaseToPatch = _mapper.Map<LegalCaseUpdateDto>(LegalCaseModelFromRepo);
            patchDoc.ApplyTo(legalcaseToPatch,ModelState);
            if(!TryValidateModel(legalcaseToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(legalcaseToPatch,LegalCaseModelFromRepo);
            _repository.UpdateLegalCase(LegalCaseModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}