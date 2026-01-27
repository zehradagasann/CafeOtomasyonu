using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CafeOtomasyonu.Entities.Interfaces;
using FluentValidation;

namespace CafeOtomasyonu.Entities.Repository
{
    // HATA BURADAYDI: "class" kelimesinden önce "public" OLMALI
    public class EntityRepositoryBase<TContext, TEntity, TValidator>
        where TContext : DbContext, new()
        where TEntity : class, IEntity, new()
        where TValidator : IValidator, new()
    {
        // Metotların başında da "public" olmalı
        public List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public bool AddOrUpdate(TContext context, TEntity entity)
        {
            TValidator validator = new TValidator();
            var validationResult = validator.Validate(entity);

            if (validationResult.IsValid)
            {
                context.Set<TEntity>().Add(entity);
                return true;
            }
            return false;
        }

        public void Save(TContext context)
        {
            context.SaveChanges();
        }
    }
}