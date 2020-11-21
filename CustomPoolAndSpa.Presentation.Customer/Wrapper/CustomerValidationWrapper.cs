using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Common.Domain;

using VNC.Core.Mvvm;
using VNC.Core.Xaml;

namespace CustomPoolAndSpa.Presentation.Customer.Wrapper
{
    public class CustomerValidationWrapper : ModelWrapper<Domain.Customer>
    //public class CustomerValidationWrapper : NotifyDataErrorInfoBase //ViewModelBase, INotifyDataErrorInfo
    {
        public CustomerValidationWrapper(Domain.Customer model) : base(model)
        {
        }

        //public Domain.Customer Model { get; set; }

        public int Id
        {
            get { return Model.Id; }
        }

        public string Title
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.Title; }
            //set
            //{
            //    Model.Title = value;
            //    OnPropertyChanged();
            //}
        }

        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }

            //get { return GetValue<string>(); }
            //set {
            //    SetValue(value);
            //    ValidateProperty(nameof(FirstName));
            //}

            //get { return Model.FirstName; }
            //set
            //{
            //    Model.FirstName = value;
            //    OnPropertyChanged();
            //    ValidateProperty(nameof(FirstName));
            //}
        }

        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.LastName; }
            //set
            //{
            //    Model.LastName = value;
            //    OnPropertyChanged();
            //}
        }

        public string CompanyName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.CompanyName; }
            //set
            //{
            //    Model.CompanyName = value;
            //    OnPropertyChanged();
            //}
        }

        public Address HomeAddress
        {
            get { return GetValue<Address>(); }
            set { SetValue(value); }
            //get { return Model.HomeAddress; }
            //set
            //{
            //    Model.HomeAddress = value;
            //    OnPropertyChanged();
            //}
        }

        public Address BillingAddress
        {
            get { return GetValue<Address>(); }
            set { SetValue(value); }
            //get { return Model.BillingAddress; }
            //set
            //{
            //    Model.BillingAddress = value;
            //    OnPropertyChanged();
            //}
        }

        public string CellPhone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.CellPhone; }
            //set
            //{
            //    Model.CellPhone = value;
            //    OnPropertyChanged();
            //}
        }

        public string WorkPhone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.WorkPhone; }
            //set
            //{
            //    Model.WorkPhone = value;
            //    OnPropertyChanged();
            //}
        }

        public string MainPhone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.MainPhone; }
            //set
            //{
            //    Model.MainPhone = value;
            //    OnPropertyChanged();
            //}
        }

        public string HomePhone
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.HomePhone; }
            //set
            //{
            //    Model.HomePhone = value;
            //    OnPropertyChanged();
            //}
        }

        public string EmailAddress
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
            //get { return Model.EmailAddress; }
            //set
            //{
            //    Model.EmailAddress = value;
            //    OnPropertyChanged();
            //}
        }

        //#region INotifyDataErrorInfo

        //private Dictionary<string, List<string>> _errorsByPropertyName
        //    = new Dictionary<string, List<string>>();

        //public bool HasErrors => _errorsByPropertyName.Any();

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    return _errorsByPropertyName.ContainsKey(propertyName)
        //        ? _errorsByPropertyName[propertyName]
        //        : null;
        //}

        //private void OnErrorsChanged(string propertyName)
        //{
        //    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        //}

        //private void AddError(string propertyName, string error)
        //{
        //    if ( ! _errorsByPropertyName.ContainsKey(propertyName))
        //    {
        //        _errorsByPropertyName[propertyName] = new List<string>();
        //    }

        //    if (!_errorsByPropertyName[propertyName].Contains(error))
        //    {
        //        _errorsByPropertyName[propertyName].Add(error);
        //        OnErrorsChanged(propertyName);
        //    }
        //}

        //private void ClearErrors(string propertyName)
        //{
        //    if (_errorsByPropertyName.ContainsKey(propertyName))
        //    {
        //        _errorsByPropertyName.Remove(propertyName);
        //        OnErrorsChanged(propertyName);
        //    }
        //}

        //#endregion

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(Title):
                    if (string.Equals(Title, "Bohunk", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Bohunks are not valid Customers";
                    }
                    break;
            }
        }

        //private void ValidateProperty(string propertyName)
        //{
        //    ClearErrors(propertyName);

        //    switch (propertyName)
        //    {
        //        case nameof(FirstName):
        //            if (string.Equals(FirstName, "Bohunk", StringComparison.OrdinalIgnoreCase))
        //            {
        //                AddError(propertyName, "Bohunks are not valid Customers");
        //            }
        //            break;
        //    }
        //}
    }
}
