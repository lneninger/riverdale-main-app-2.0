﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand.Models;

namespace ApplicationLogic.Business.Commands.ProductColorType.GetAllCommand
{
    public class ProductColorTypeGetAllCommand : AbstractDBCommand<DomainModel.ProductColorType, IProductColorTypeDBRepository>, IProductColorTypeGetAllCommand
    {
        public ProductColorTypeGetAllCommand(IDbContextScopeFactory dbContextScopeFactory, IProductColorTypeDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public IEnumerable<ProductColorTypeGetAllCommandOutputDTO> Execute()
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.GetAll();
            }
        }
    }
}