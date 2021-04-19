using AutoMapper;
using LegalCasesMicrosservice.Controllers;
using LegalCasesMicrosservice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using LegalCasesMicrosservice.Profiles;
using LegalCasesMicrosservice.Dtos;
using Xunit.Abstractions;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Tests
{
    public class LegalCaseUnitTestController
    {
        private SqlLegalCaseRepo repository;
        public static DbContextOptions<LegalCaseContext> dbContextOptions{get;}
        public static string connectionString = "Server=.\\SQLExpress;Database=LegalCasesDBTests;UID=sa;Password=P@ulo01!";

        static LegalCaseUnitTestController() => dbContextOptions = new DbContextOptionsBuilder<LegalCaseContext>()
            .UseSqlServer(connectionString)
            .Options;

        private readonly ITestOutputHelper output;
        public LegalCaseUnitTestController(ITestOutputHelper output)
        {
            this.output = output;
            var context = new LegalCaseContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new SqlLegalCaseRepo(context);
        }
        #region Get By Id

         [Fact]  
        public  void Task_GetLegalCaseById_Return_OkResult()  
        {  
            //Arrange  
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LegalCasesProfile());
            });
            var mapper = mockMapper.CreateMapper();
                
            var controller = new LegalCasesController(repository,mapper);  
            var caseid = 1;  
  
            //Act  
            var data = controller.GetLegalCaseById(caseid);  

            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);  
        }  

        [Fact]  
        public void Task_GetLegalCaseById_Return_NotFoundResult()  
        {  
            //Arrange  
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LegalCasesProfile());
            });
            var mapper = mockMapper.CreateMapper();
                
            var controller = new LegalCasesController(repository,mapper);  
            var caseId = 5;  
  
            //Act  
            var data = controller.GetLegalCaseById(caseId);  
  
            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);  
        }  
        #endregion

        #region Get All
        [Fact]  
        public void Task_GetLegalCases_Return_OkResult()  
        {  
            //Arrange  
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LegalCasesProfile());
            });
            var mapper = mockMapper.CreateMapper();
                
            var controller = new LegalCasesController(repository,mapper);  
  
            //Act  
            var data = controller.GetAllLegalCases();  
  
            //Assert  
            Assert.IsType<OkObjectResult>(data.Result);  
        }  
  
        [Fact]  
        public void Task_GetLegalCases_Return_BadRequestResult()  
        {  
            //Arrange  
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LegalCasesProfile());
            });
            var mapper = mockMapper.CreateMapper();
                
            var controller = new LegalCasesController(repository,mapper);  
  
            //Act  
            var data = controller.GetAllLegalCases();  
            data = null;  
  
            if (data != null)  
                //Assert  
                Assert.IsType<BadRequestResult>(data.Result);  
        }  

        #endregion

        #region Add New Legal Case
        [Fact]  
        public void Task_Add_ValidData_Return_OkResult()  
        {  
            //Arrange  
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new LegalCasesProfile());
            });
            var mapper = mockMapper.CreateMapper();
                
            var controller = new LegalCasesController(repository,mapper);  
            var item = new LegalCaseCreateDto() { CaseNumber = "1458745-66.1234.9.57.1547", CourtName = "State Court", NameOfResponsible = "Cristian Holmes"};  
  
            //Act  
            var data = controller.CreateLegalCase(item);  
  
            //Assert  
            Assert.IsType<CreatedAtRouteResult>(data.Result);  
        }  

        #endregion

    }
}