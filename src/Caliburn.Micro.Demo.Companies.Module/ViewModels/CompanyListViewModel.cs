﻿using Caliburn.Micro.Demo.Companies.Module.Model;
using Caliburn.Micro.Demo.Contracts;
using Caliburn.Micro.Demo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Demo.Companies.Module.ViewModels
{
    public class CompanyListViewModel : ViewModelBase, IContent, IHandle<AddItemEvent>
    {
        private readonly IEventAggregator _eventAggregator;

        public CompanyListViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            
            Companies = new ObservableCollection<Company>();
            Companies.Add(new Company("Microsoft", "USA"));
            Companies.Add(new Company("Google", "USA"));
            Companies.Add(new Company("Amazon", "USA"));
        }

        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                NotifyOfPropertyChange(() => Companies);
            }
        }

        public void Handle(AddItemEvent message)
        {
            Companies.Add(new Company(message.Name, "USA"));
        }
    }
}
