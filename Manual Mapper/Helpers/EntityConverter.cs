using Manual_Mapper.Interfaces;

namespace Manual_Mapper.Helper
{
    public class GenericEntityConverter<TDTO, TEntity> : IEntityConverter<TDTO, TEntity>
        where TEntity : class, new()
        where TDTO : class, new()
    {
        private readonly ICurrentUserBusiness _currentUserBusiness;

        public GenericEntityConverter(ICurrentUserBusiness currentUserBusiness)
        {
            _currentUserBusiness = currentUserBusiness;
        }

        public TEntity ToEntity(TDTO dto, TEntity entity = null, Dictionary<string, string> customMappings = null)
        {
            if (entity == null)
            {
                entity = new TEntity();

                var createdByProperty = entity.GetType().GetProperty("CreatedBy");
                if (createdByProperty != null && createdByProperty.CanWrite)
                {
                    var userId = _currentUserBusiness.GetCurrentUserId();
                    createdByProperty.SetValue(entity, Guid.TryParse(userId, out var guid) ? guid : Guid.Empty);
                }

                var createdDateProperty = entity.GetType().GetProperty("CreatedDate");
                if (createdDateProperty != null && createdDateProperty.CanWrite)
                {
                    createdDateProperty.SetValue(entity, DateTimeOffset.UtcNow.DateTime);
                }
            }

            var dtoProperties = dto.GetType().GetProperties();

            foreach (var property in dtoProperties)
            {

                string entityPropName = property.Name;
                if (customMappings != null && customMappings.ContainsKey(property.Name))
                {
                    entityPropName = customMappings[property.Name];
                }

                var entityProperty = entity.GetType().GetProperty(entityPropName);
                if (entityProperty != null && entityProperty.CanWrite)
                {
                    entityProperty.SetValue(entity, property.GetValue(dto));
                }
            }

            var currentUserId = _currentUserBusiness.GetCurrentUserId();

            var modifiedByProperty = entity.GetType().GetProperty("ModifiedBy");
            if (modifiedByProperty != null && modifiedByProperty.CanWrite)
            {
                modifiedByProperty.SetValue(entity, Guid.TryParse(currentUserId, out var guid) ? guid : Guid.Empty);
            }

            var modifiedDateProperty = entity.GetType().GetProperty("ModifiedDate");
            if (modifiedDateProperty != null && modifiedDateProperty.CanWrite)
            {
                modifiedDateProperty.SetValue(entity, DateTimeOffset.UtcNow.DateTime);
            }

            return entity;
        }

        public TDTO ToDTO(TEntity entity, Dictionary<string, string> customMappings = null)
        {
            if (entity == null) return default;

            var dto = new TDTO();
            var entityProperties = entity.GetType().GetProperties();


            Dictionary<string, string> reverseMappings = null;
            if (customMappings != null)
            {
                reverseMappings = customMappings.ToDictionary(pair => pair.Value, pair => pair.Key);
            }

            foreach (var property in entityProperties)
            {

                string dtoPropName = property.Name;
                if (reverseMappings != null && reverseMappings.ContainsKey(property.Name))
                {
                    dtoPropName = reverseMappings[property.Name];
                }

                var dtoProperty = dto.GetType().GetProperty(dtoPropName);
                if (dtoProperty != null && dtoProperty.CanWrite)
                {
                    dtoProperty.SetValue(dto, property.GetValue(entity));
                }
            }

            return dto;
        }
    }
}
