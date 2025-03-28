﻿using AMSS.Entities;

namespace AMSS.Repositories.IRepository
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task<List<Field>> GetAllFieldWithDetailAsync();
        Task<Field> Update(Field field);
    }
}
