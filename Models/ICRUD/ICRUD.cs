using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ICRUD
{
    public interface ICRUD
    {
        int CreateModel(AppModels.ISystemModel model);
        AppModels.ISystemModel ReadModel(int id);
        ICollection<AppModels.ISystemModel> ReadAllModes();
        ICollection<AppModels.ISystemModel> ReadMultipleModels(ICollection<int> ids);
        int UpdateModel(AppModels.ISystemModel model);
        int DeleteModel(int id);

        DTOConversion.IConvertModels _Converter { get; set; }
    }
}
