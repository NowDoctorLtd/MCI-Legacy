﻿using System;
using mci_main.Models;

namespace mci_main.Repository
{
    public interface ISearchRepository
    {
        public SearchResults Search(string query);
    }
}

