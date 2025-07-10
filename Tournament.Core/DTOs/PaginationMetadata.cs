﻿
namespace Tournament.Core.DTOs
{
    public class PaginationMetadata
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
    }
}
