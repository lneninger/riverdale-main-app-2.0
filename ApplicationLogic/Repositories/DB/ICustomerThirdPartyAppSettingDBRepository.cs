using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.DeleteCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.InsertCommand.Models;
using ApplicationLogic.Business.Commands.CustomerThirdPartyAppSetting.PageQueryCommand.Models;
using DomainModel.Company.Customer;
using Framework.Core.Messages;
using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System.Collections.Generic;

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
