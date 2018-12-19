using DomainModel;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetAllCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.GetByIdCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.UpdateCommand.Models;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core.Messages;

namespace ApplicationLogic.Repositories.DB
{
    public interface ICustomerThirdPartyAppSettingDBRepository : IDBRepository
    {
        OperationResponse<IEnumerable<CustomerThirdPartyAppSetting>> GetAll();
        OperationResponse<PageResult<CustomerThirdPartyAppSettingPageQueryCommandOutputDTO>> PageQuery(PageQuery<CustomerThirdPartyAppSettingPageQueryCommandInputDTO> input);
        OperationResponse<CustomerThirdPartyAppSetting> GetById(int id);
        OperationResponse<CustomerThirdPartyAppSettingInsertCommandOutputDTO> Insert(CustomerThirdPartyAppSettingInsertCommandInputDTO input);
        //OperationResponse<CustomerThirdPartyAppSettingUpdateCommandOutputDTO> Update(CustomerThirdPartyAppSettingUpdateCommandInputDTO input);
        OperationResponse<CustomerThirdPartyAppSettingDeleteCommandOutputDTO> Delete(int id);
    }
}
