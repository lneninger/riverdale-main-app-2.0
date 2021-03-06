﻿using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.DbContextScope;
using ApplicationLogic.Repositories.DB;
using ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using Framework.Core.Messages;

namespace ApplicationLogic.Business.Commands.SampleBoxProduct.PageQueryCommand
{
    public class SampleBoxProductPageQueryCommand : AbstractDBCommand<DomainModel.SaleOpportunity.SampleBoxProduct, ISampleBoxProductDBRepository>, ISampleBoxProductPageQueryCommand
    {
        public SampleBoxProductPageQueryCommand(IDbContextScopeFactory dbContextScopeFactory, ISampleBoxProductDBRepository repository) : base(dbContextScopeFactory, repository)
        {
        }

        public OperationResponse<PageResult<SampleBoxProductPageQueryCommandOutputDTO>> Execute(PageQuery<SampleBoxProductPageQueryCommandInputDTO> input)
        {
            using (var dbContextScope = this.DbContextScopeFactory.Create())
            {
                return this.Repository.PageQuery(input);
            }
        }
    }
}
