﻿namespace Product_Scraping.Pagination
{
    public class ProductsParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize 
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
