using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_Mapper.Interfaces
{
    public interface IEntityConverter<TDTO, TEntity> where TEntity : class
    {
        TEntity ToEntity(TDTO dto, TEntity entity = null, Dictionary<string, string> customMappings = null);
        TDTO ToDTO(TEntity entity, Dictionary<string, string> customMappings = null);
    }
}
