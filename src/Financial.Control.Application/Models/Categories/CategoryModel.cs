﻿using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Models.Categories;

namespace Financial.Control.Application.Models.Categories
{
    public sealed class CategoryModel : BaseModel, ICategoryModel
    {
        public string Name { get; }
        private CategoryModel(Category category) : base(category.Id, category.CreationDate, category.UpdateDate)
        {
            Name = category.Name;
        }

        #region Factory
        public static CategoryModel Create(Category category) => new CategoryModel(category);
        #endregion
    }
}
