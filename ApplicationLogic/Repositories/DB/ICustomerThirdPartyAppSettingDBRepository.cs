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

namespace FocusApplication.Repositories.DB
{
    public interface ICustomerThirdPartyAppSettingDBRepository : IDBRepository
    {
        IEnumerable<CustomerThirdPartyAppSettingGetAllCommandOutputDTO> GetAll();
        PageResult<CustomerThirdPartyAppSettingPageQueryCommandOutputDTO> PageQuery(PageQuery<CustomerThirdPartyAppSettingPageQueryCommandInputDTO> input);
        CustomerThirdPartyAppSettingGetByIdCommandOutputDTO GetById(int id);
        CustomerThirdPartyAppSettingInsertCommandOutputDTO Insert(CustomerThirdPartyAppSettingInsertCommandInputDTO input);
        CustomerThirdPartyAppSettingUpdateCommandOutputDTO Update(CustomerThirdPartyAppSettingUpdateCommandInputDTO input);
        CustomerThirdPartyAppSettingDeleteCommandOutputDTO Delete(int id);
    }
}
