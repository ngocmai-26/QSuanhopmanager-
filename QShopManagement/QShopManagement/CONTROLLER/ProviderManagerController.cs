using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QShopManagement.DTO.UC;
using QShopManagement.MODEL.DAO;
using QShopManagement.MODEL.EF;
using System.Windows.Forms;

namespace QShopManagement.CONTROLLER
{
    class ProviderManagerController
    {
        UCProviderManager providerM;
        public ProviderManagerDao model;
        public ProviderManagerController(UCProviderManager providerM_)
        {

            providerM = providerM_;
            model = new ProviderManagerDao();
        }
        public async void GetListProviders()
        {
            bool check = await model.GetListProviders();
            if (check)
            {
                providerM.LoadDataToShow(model);
            }
        }
        public async Task<bool> CheckIfHas(string ID)
        {
            try
            {
                var ef = await model.GetSingleByID(ID);
                if (ef != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public async void AddProvider(tbl_NHACUNGCAP provider)
        {
            bool isHas = await CheckIfHas(provider.MaNCC);
            if (isHas)
            {
                MessageBox.Show("Nhân Viên Đã Tồn Tại Không Thể Thêm (MSNV Trùng)");
            }
            else
            {
                bool checkIsAdded = await model.AddProvider(provider);
                if (checkIsAdded)
                {
                    providerM.ReLoadSource();
                }
            }
        }
        internal async void UpdateProvider(tbl_NHACUNGCAP provider)
        {
            try
            {
                if (provider != null)
                {
                    bool check = await model.UpdateProvider(provider);
                    if (check)
                    {
                        providerM.ReLoadSource();
                    }
                    else
                    {
                        MessageBox.Show("Có 1 số lỗi xảy ra khi sửa dữ liệu");
                    }
                }
            }
            catch
            {

            }
        }
        internal async void RemovePovider(string ID)
        {
            if (await model.RemovePovider(ID))
            {
                providerM.ReLoadSource();
            }
            else
            {
                MessageBox.Show("Something err");
            }
        }
    }
}