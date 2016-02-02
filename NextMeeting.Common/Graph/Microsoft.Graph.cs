﻿namespace Microsoft.Graph

{

    using global::Microsoft.OData.Client;

    using global::Microsoft.OData.Edm;

    using System;

    using System.Collections.Generic;

    using System.ComponentModel;

    using System.Linq;

    using System.Reflection;

    using System.Threading.Tasks;

    public enum AttendeeType : int

    {

        required
         = 0
        ,
        optional
         = 1
        ,
        resource
         = 2
        ,
    }



    public enum FreeBusyStatus : int

    {

        free
         = 0
        ,
        tentative
         = 1
        ,
        busy
         = 2
        ,
        oof
         = 3
        ,
        workingElsewhere
         = 4
        ,
        unknown
         = -1
        ,
    }



    public enum ActivityDomain : int

    {

        unknown
         = 0
        ,
        work
         = 1
        ,
        personal
         = 2
        ,
    }



    public enum BodyType : int

    {

        text
         = 0
        ,
        html
         = 1
        ,
    }



    public enum Importance : int

    {

        low
         = 0
        ,
        normal
         = 1
        ,
        high
         = 2
        ,
    }



    public enum InferenceClassificationType : int

    {

        focused
         = 0
        ,
        other
         = 1
        ,
    }



    public enum CalendarColor : int

    {

        lightBlue
         = 0
        ,
        lightGreen
         = 1
        ,
        lightOrange
         = 2
        ,
        lightGray
         = 3
        ,
        lightYellow
         = 4
        ,
        lightTeal
         = 5
        ,
        lightPink
         = 6
        ,
        lightBrown
         = 7
        ,
        lightRed
         = 8
        ,
        maxColor
         = 9
        ,
        auto
         = -1
        ,
    }



    public enum ResponseType : int

    {

        none
         = 0
        ,
        organizer
         = 1
        ,
        tentativelyAccepted
         = 2
        ,
        accepted
         = 3
        ,
        declined
         = 4
        ,
        notResponded
         = 5
        ,
    }



    public enum Sensitivity : int

    {

        normal
         = 0
        ,
        personal
         = 1
        ,
        Private
         = 2
        ,
        confidential
         = 3
        ,
    }



    public enum RecurrencePatternType : int

    {

        daily
         = 0
        ,
        weekly
         = 1
        ,
        absoluteMonthly
         = 2
        ,
        relativeMonthly
         = 3
        ,
        absoluteYearly
         = 4
        ,
        relativeYearly
         = 5
        ,
    }



    public enum DayOfWeek : int

    {

        sunday
         = 0
        ,
        monday
         = 1
        ,
        tuesday
         = 2
        ,
        wednesday
         = 3
        ,
        thursday
         = 4
        ,
        friday
         = 5
        ,
        saturday
         = 6
        ,
    }



    public enum WeekIndex : int

    {

        first
         = 0
        ,
        second
         = 1
        ,
        third
         = 2
        ,
        fourth
         = 3
        ,
        last
         = 4
        ,
    }



    public enum RecurrenceRangeType : int

    {

        endDate
         = 0
        ,
        noEnd
         = 1
        ,
        numbered
         = 2
        ,
    }



    public enum EventType : int

    {

        singleInstance
         = 0
        ,
        occurrence
         = 1
        ,
        exception
         = 2
        ,
        seriesMaster
         = 3
        ,
    }



    public enum MeetingMessageType : int

    {

        none
         = 0
        ,
        meetingRequest
         = 1
        ,
        meetingCancelled
         = 2
        ,
        meetingAccepted
         = 3
        ,
        meetingTenativelyAccepted
         = 4
        ,
        meetingDeclined
         = 5
        ,
    }



    public enum GroupAccessType : int

    {

        none
         = 0
        ,
        Private
         = 1
            ,
        secret
         = 2
            ,
        Public
         = 3
            ,
    }



    public enum PatchInsertPosition : int

    {

        After
         = 0
        ,
        Before
         = 1
        ,
    }



    public enum PatchActionType : int

    {

        Replace
         = 0
        ,
        Append
         = 1
        ,
        Delete
         = 2
        ,
        Insert
         = 3
        ,
        Prepend
         = 4
        ,
    }



    public enum UserRole : int

    {

        Owner
         = 0
        ,
        Contributor
         = 1
        ,
        Reader
         = 2
        ,
        None
         = -1
        ,
    }



    public enum TaskBoardType : int

    {

        progress
         = 0
        ,
        assignedTo
         = 1
        ,
        bucket
         = 2
        ,
    }



    public enum PreviewType : int

    {

        automatic
         = 0
        ,
        noPreview
         = 1
        ,
        checklist
         = 2
        ,
        description
         = 3
        ,
        reference
         = 4
        ,
    }



    public partial class AddIn : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Guid> _id;

        private System.String _type;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.KeyValue> _properties;

        public System.Nullable<System.Guid> Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.KeyValue> Properties

        {

            get

            {

                if (this._properties == default(System.Collections.Generic.IList<global::Microsoft.Graph.KeyValue>))

                {

                    this._properties = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.KeyValue>();

                    this._properties.SetContainer(() => GetContainingEntity("properties"));

                }

                return this._properties;

            }

            set

            {

                Properties.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Properties.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.Nullable<System.Guid> id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Properties instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.KeyValue> properties

        {

            get

            {

                return Properties;

            }

            set

            {

                Properties = value;

            }

        }

        public AddIn() : base()

        {

        }

    }

    public partial class KeyValue : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _key;

        private System.String _value;

        public System.String Key

        {

            get

            {

                return _key;

            }

            set

            {

                if (value != _key)

                {

                    _key = value;

                    OnPropertyChanged("key");

                }

            }

        }

        public System.String Value

        {

            get

            {

                return _value;

            }

            set

            {

                if (value != _value)

                {

                    _value = value;

                    OnPropertyChanged("value");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Key instead.")]

        public System.String key

        {

            get

            {

                return Key;

            }

            set

            {

                Key = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Value instead.")]

        public System.String value

        {

            get

            {

                return Value;

            }

            set

            {

                Value = value;

            }

        }

        public KeyValue() : base()

        {

        }

    }

    public partial class AppRole : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _allowedMemberTypes;

        private System.String _description;

        private System.String _displayName;

        private System.Guid _id;

        private System.Boolean _isEnabled;

        private System.String _origin;

        private System.String _value;

        public System.Collections.Generic.IList<System.String> AllowedMemberTypes

        {

            get

            {

                if (this._allowedMemberTypes == default(System.Collections.Generic.IList<System.String>))

                {

                    this._allowedMemberTypes = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._allowedMemberTypes.SetContainer(() => GetContainingEntity("allowedMemberTypes"));

                }

                return this._allowedMemberTypes;

            }

            set

            {

                AllowedMemberTypes.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AllowedMemberTypes.Add(i);

                    }

                }

            }

        }

        public System.String Description

        {

            get

            {

                return _description;

            }

            set

            {

                if (value != _description)

                {

                    _description = value;

                    OnPropertyChanged("description");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.Guid Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.Boolean IsEnabled

        {

            get

            {

                return _isEnabled;

            }

            set

            {

                if (value != _isEnabled)

                {

                    _isEnabled = value;

                    OnPropertyChanged("isEnabled");

                }

            }

        }

        public System.String Origin

        {

            get

            {

                return _origin;

            }

            set

            {

                if (value != _origin)

                {

                    _origin = value;

                    OnPropertyChanged("origin");

                }

            }

        }

        public System.String Value

        {

            get

            {

                return _value;

            }

            set

            {

                if (value != _value)

                {

                    _value = value;

                    OnPropertyChanged("value");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AllowedMemberTypes instead.")]

        public global::System.Collections.Generic.IList<System.String> allowedMemberTypes

        {

            get

            {

                return AllowedMemberTypes;

            }

            set

            {

                AllowedMemberTypes = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Description instead.")]

        public System.String description

        {

            get

            {

                return Description;

            }

            set

            {

                Description = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.Guid id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsEnabled instead.")]

        public System.Boolean isEnabled

        {

            get

            {

                return IsEnabled;

            }

            set

            {

                IsEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Origin instead.")]

        public System.String origin

        {

            get

            {

                return Origin;

            }

            set

            {

                Origin = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Value instead.")]

        public System.String value

        {

            get

            {

                return Value;

            }

            set

            {

                Value = value;

            }

        }

        public AppRole() : base()

        {

        }

    }

    public partial class KeyCredential : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Byte[] _customKeyIdentifier;

        private System.Nullable<System.DateTimeOffset> _endDate;

        private System.Nullable<System.Guid> _keyId;

        private System.Nullable<System.DateTimeOffset> _startDate;

        private System.String _type;

        private System.String _usage;

        private System.Byte[] _value;

        public System.Byte[] CustomKeyIdentifier

        {

            get

            {

                return _customKeyIdentifier;

            }

            set

            {

                if (value != _customKeyIdentifier)

                {

                    _customKeyIdentifier = value;

                    OnPropertyChanged("customKeyIdentifier");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> EndDate

        {

            get

            {

                return _endDate;

            }

            set

            {

                if (value != _endDate)

                {

                    _endDate = value;

                    OnPropertyChanged("endDate");

                }

            }

        }

        public System.Nullable<System.Guid> KeyId

        {

            get

            {

                return _keyId;

            }

            set

            {

                if (value != _keyId)

                {

                    _keyId = value;

                    OnPropertyChanged("keyId");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> StartDate

        {

            get

            {

                return _startDate;

            }

            set

            {

                if (value != _startDate)

                {

                    _startDate = value;

                    OnPropertyChanged("startDate");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.String Usage

        {

            get

            {

                return _usage;

            }

            set

            {

                if (value != _usage)

                {

                    _usage = value;

                    OnPropertyChanged("usage");

                }

            }

        }

        public System.Byte[] Value

        {

            get

            {

                return _value;

            }

            set

            {

                if (value != _value)

                {

                    _value = value;

                    OnPropertyChanged("value");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CustomKeyIdentifier instead.")]

        public System.Byte[] customKeyIdentifier

        {

            get

            {

                return CustomKeyIdentifier;

            }

            set

            {

                CustomKeyIdentifier = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EndDate instead.")]

        public System.Nullable<System.DateTimeOffset> endDate

        {

            get

            {

                return EndDate;

            }

            set

            {

                EndDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use KeyId instead.")]

        public System.Nullable<System.Guid> keyId

        {

            get

            {

                return KeyId;

            }

            set

            {

                KeyId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use StartDate instead.")]

        public System.Nullable<System.DateTimeOffset> startDate

        {

            get

            {

                return StartDate;

            }

            set

            {

                StartDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Usage instead.")]

        public System.String usage

        {

            get

            {

                return Usage;

            }

            set

            {

                Usage = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Value instead.")]

        public System.Byte[] value

        {

            get

            {

                return Value;

            }

            set

            {

                Value = value;

            }

        }

        public KeyCredential() : base()

        {

        }

    }

    public partial class OAuth2Permission : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _adminConsentDescription;

        private System.String _adminConsentDisplayName;

        private System.Guid _id;

        private System.Boolean _isEnabled;

        private System.String _origin;

        private System.String _type;

        private System.String _userConsentDescription;

        private System.String _userConsentDisplayName;

        private System.String _value;

        public System.String AdminConsentDescription

        {

            get

            {

                return _adminConsentDescription;

            }

            set

            {

                if (value != _adminConsentDescription)

                {

                    _adminConsentDescription = value;

                    OnPropertyChanged("adminConsentDescription");

                }

            }

        }

        public System.String AdminConsentDisplayName

        {

            get

            {

                return _adminConsentDisplayName;

            }

            set

            {

                if (value != _adminConsentDisplayName)

                {

                    _adminConsentDisplayName = value;

                    OnPropertyChanged("adminConsentDisplayName");

                }

            }

        }

        public System.Guid Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.Boolean IsEnabled

        {

            get

            {

                return _isEnabled;

            }

            set

            {

                if (value != _isEnabled)

                {

                    _isEnabled = value;

                    OnPropertyChanged("isEnabled");

                }

            }

        }

        public System.String Origin

        {

            get

            {

                return _origin;

            }

            set

            {

                if (value != _origin)

                {

                    _origin = value;

                    OnPropertyChanged("origin");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.String UserConsentDescription

        {

            get

            {

                return _userConsentDescription;

            }

            set

            {

                if (value != _userConsentDescription)

                {

                    _userConsentDescription = value;

                    OnPropertyChanged("userConsentDescription");

                }

            }

        }

        public System.String UserConsentDisplayName

        {

            get

            {

                return _userConsentDisplayName;

            }

            set

            {

                if (value != _userConsentDisplayName)

                {

                    _userConsentDisplayName = value;

                    OnPropertyChanged("userConsentDisplayName");

                }

            }

        }

        public System.String Value

        {

            get

            {

                return _value;

            }

            set

            {

                if (value != _value)

                {

                    _value = value;

                    OnPropertyChanged("value");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AdminConsentDescription instead.")]

        public System.String adminConsentDescription

        {

            get

            {

                return AdminConsentDescription;

            }

            set

            {

                AdminConsentDescription = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AdminConsentDisplayName instead.")]

        public System.String adminConsentDisplayName

        {

            get

            {

                return AdminConsentDisplayName;

            }

            set

            {

                AdminConsentDisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.Guid id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsEnabled instead.")]

        public System.Boolean isEnabled

        {

            get

            {

                return IsEnabled;

            }

            set

            {

                IsEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Origin instead.")]

        public System.String origin

        {

            get

            {

                return Origin;

            }

            set

            {

                Origin = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UserConsentDescription instead.")]

        public System.String userConsentDescription

        {

            get

            {

                return UserConsentDescription;

            }

            set

            {

                UserConsentDescription = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UserConsentDisplayName instead.")]

        public System.String userConsentDisplayName

        {

            get

            {

                return UserConsentDisplayName;

            }

            set

            {

                UserConsentDisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Value instead.")]

        public System.String value

        {

            get

            {

                return Value;

            }

            set

            {

                Value = value;

            }

        }

        public OAuth2Permission() : base()

        {

        }

    }

    public partial class PasswordCredential : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Byte[] _customKeyIdentifier;

        private System.Nullable<System.DateTimeOffset> _endDate;

        private System.Nullable<System.Guid> _keyId;

        private System.Nullable<System.DateTimeOffset> _startDate;

        private System.String _value;

        public System.Byte[] CustomKeyIdentifier

        {

            get

            {

                return _customKeyIdentifier;

            }

            set

            {

                if (value != _customKeyIdentifier)

                {

                    _customKeyIdentifier = value;

                    OnPropertyChanged("customKeyIdentifier");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> EndDate

        {

            get

            {

                return _endDate;

            }

            set

            {

                if (value != _endDate)

                {

                    _endDate = value;

                    OnPropertyChanged("endDate");

                }

            }

        }

        public System.Nullable<System.Guid> KeyId

        {

            get

            {

                return _keyId;

            }

            set

            {

                if (value != _keyId)

                {

                    _keyId = value;

                    OnPropertyChanged("keyId");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> StartDate

        {

            get

            {

                return _startDate;

            }

            set

            {

                if (value != _startDate)

                {

                    _startDate = value;

                    OnPropertyChanged("startDate");

                }

            }

        }

        public System.String Value

        {

            get

            {

                return _value;

            }

            set

            {

                if (value != _value)

                {

                    _value = value;

                    OnPropertyChanged("value");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CustomKeyIdentifier instead.")]

        public System.Byte[] customKeyIdentifier

        {

            get

            {

                return CustomKeyIdentifier;

            }

            set

            {

                CustomKeyIdentifier = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EndDate instead.")]

        public System.Nullable<System.DateTimeOffset> endDate

        {

            get

            {

                return EndDate;

            }

            set

            {

                EndDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use KeyId instead.")]

        public System.Nullable<System.Guid> keyId

        {

            get

            {

                return KeyId;

            }

            set

            {

                KeyId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use StartDate instead.")]

        public System.Nullable<System.DateTimeOffset> startDate

        {

            get

            {

                return StartDate;

            }

            set

            {

                StartDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Value instead.")]

        public System.String value

        {

            get

            {

                return Value;

            }

            set

            {

                Value = value;

            }

        }

        public PasswordCredential() : base()

        {

        }

    }

    public partial class RequiredResourceAccess : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _resourceAppId;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ResourceAccess> _resourceAccess;

        public System.String ResourceAppId

        {

            get

            {

                return _resourceAppId;

            }

            set

            {

                if (value != _resourceAppId)

                {

                    _resourceAppId = value;

                    OnPropertyChanged("resourceAppId");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.ResourceAccess> ResourceAccess

        {

            get

            {

                if (this._resourceAccess == default(System.Collections.Generic.IList<global::Microsoft.Graph.ResourceAccess>))

                {

                    this._resourceAccess = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ResourceAccess>();

                    this._resourceAccess.SetContainer(() => GetContainingEntity("resourceAccess"));

                }

                return this._resourceAccess;

            }

            set

            {

                ResourceAccess.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ResourceAccess.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResourceAppId instead.")]

        public System.String resourceAppId

        {

            get

            {

                return ResourceAppId;

            }

            set

            {

                ResourceAppId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResourceAccess instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ResourceAccess> resourceAccess

        {

            get

            {

                return ResourceAccess;

            }

            set

            {

                ResourceAccess = value;

            }

        }

        public RequiredResourceAccess() : base()

        {

        }

    }

    public partial class ResourceAccess : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Guid _id;

        private System.String _type;

        public System.Guid Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.Guid id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        public ResourceAccess() : base()

        {

        }

    }

    public partial class AlternativeSecurityId : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Int32> _type;

        private System.String _identityProvider;

        private System.Byte[] _key;

        public System.Nullable<System.Int32> Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.String IdentityProvider

        {

            get

            {

                return _identityProvider;

            }

            set

            {

                if (value != _identityProvider)

                {

                    _identityProvider = value;

                    OnPropertyChanged("identityProvider");

                }

            }

        }

        public System.Byte[] Key

        {

            get

            {

                return _key;

            }

            set

            {

                if (value != _key)

                {

                    _key = value;

                    OnPropertyChanged("key");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.Nullable<System.Int32> type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IdentityProvider instead.")]

        public System.String identityProvider

        {

            get

            {

                return IdentityProvider;

            }

            set

            {

                IdentityProvider = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Key instead.")]

        public System.Byte[] key

        {

            get

            {

                return Key;

            }

            set

            {

                Key = value;

            }

        }

        public AlternativeSecurityId() : base()

        {

        }

    }

    public partial class LicenseUnitsDetail : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Int32> _enabled;

        private System.Nullable<System.Int32> _suspended;

        private System.Nullable<System.Int32> _warning;

        public System.Nullable<System.Int32> Enabled

        {

            get

            {

                return _enabled;

            }

            set

            {

                if (value != _enabled)

                {

                    _enabled = value;

                    OnPropertyChanged("enabled");

                }

            }

        }

        public System.Nullable<System.Int32> Suspended

        {

            get

            {

                return _suspended;

            }

            set

            {

                if (value != _suspended)

                {

                    _suspended = value;

                    OnPropertyChanged("suspended");

                }

            }

        }

        public System.Nullable<System.Int32> Warning

        {

            get

            {

                return _warning;

            }

            set

            {

                if (value != _warning)

                {

                    _warning = value;

                    OnPropertyChanged("warning");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Enabled instead.")]

        public System.Nullable<System.Int32> enabled

        {

            get

            {

                return Enabled;

            }

            set

            {

                Enabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Suspended instead.")]

        public System.Nullable<System.Int32> suspended

        {

            get

            {

                return Suspended;

            }

            set

            {

                Suspended = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Warning instead.")]

        public System.Nullable<System.Int32> warning

        {

            get

            {

                return Warning;

            }

            set

            {

                Warning = value;

            }

        }

        public LicenseUnitsDetail() : base()

        {

        }

    }

    public partial class ServicePlanInfo : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Guid> _servicePlanId;

        private System.String _servicePlanName;

        private System.String _provisioningStatus;

        private System.String _appliesTo;

        public System.Nullable<System.Guid> ServicePlanId

        {

            get

            {

                return _servicePlanId;

            }

            set

            {

                if (value != _servicePlanId)

                {

                    _servicePlanId = value;

                    OnPropertyChanged("servicePlanId");

                }

            }

        }

        public System.String ServicePlanName

        {

            get

            {

                return _servicePlanName;

            }

            set

            {

                if (value != _servicePlanName)

                {

                    _servicePlanName = value;

                    OnPropertyChanged("servicePlanName");

                }

            }

        }

        public System.String ProvisioningStatus

        {

            get

            {

                return _provisioningStatus;

            }

            set

            {

                if (value != _provisioningStatus)

                {

                    _provisioningStatus = value;

                    OnPropertyChanged("provisioningStatus");

                }

            }

        }

        public System.String AppliesTo

        {

            get

            {

                return _appliesTo;

            }

            set

            {

                if (value != _appliesTo)

                {

                    _appliesTo = value;

                    OnPropertyChanged("appliesTo");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ServicePlanId instead.")]

        public System.Nullable<System.Guid> servicePlanId

        {

            get

            {

                return ServicePlanId;

            }

            set

            {

                ServicePlanId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ServicePlanName instead.")]

        public System.String servicePlanName

        {

            get

            {

                return ServicePlanName;

            }

            set

            {

                ServicePlanName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProvisioningStatus instead.")]

        public System.String provisioningStatus

        {

            get

            {

                return ProvisioningStatus;

            }

            set

            {

                ProvisioningStatus = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppliesTo instead.")]

        public System.String appliesTo

        {

            get

            {

                return AppliesTo;

            }

            set

            {

                AppliesTo = value;

            }

        }

        public ServicePlanInfo() : base()

        {

        }

    }

    public partial class AssignedPlan : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.DateTimeOffset> _assignedDateTime;

        private System.String _capabilityStatus;

        private System.String _service;

        private System.Nullable<System.Guid> _servicePlanId;

        public System.Nullable<System.DateTimeOffset> AssignedDateTime

        {

            get

            {

                return _assignedDateTime;

            }

            set

            {

                if (value != _assignedDateTime)

                {

                    _assignedDateTime = value;

                    OnPropertyChanged("assignedDateTime");

                }

            }

        }

        public System.String CapabilityStatus

        {

            get

            {

                return _capabilityStatus;

            }

            set

            {

                if (value != _capabilityStatus)

                {

                    _capabilityStatus = value;

                    OnPropertyChanged("capabilityStatus");

                }

            }

        }

        public System.String Service

        {

            get

            {

                return _service;

            }

            set

            {

                if (value != _service)

                {

                    _service = value;

                    OnPropertyChanged("service");

                }

            }

        }

        public System.Nullable<System.Guid> ServicePlanId

        {

            get

            {

                return _servicePlanId;

            }

            set

            {

                if (value != _servicePlanId)

                {

                    _servicePlanId = value;

                    OnPropertyChanged("servicePlanId");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AssignedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> assignedDateTime

        {

            get

            {

                return AssignedDateTime;

            }

            set

            {

                AssignedDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CapabilityStatus instead.")]

        public System.String capabilityStatus

        {

            get

            {

                return CapabilityStatus;

            }

            set

            {

                CapabilityStatus = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Service instead.")]

        public System.String service

        {

            get

            {

                return Service;

            }

            set

            {

                Service = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ServicePlanId instead.")]

        public System.Nullable<System.Guid> servicePlanId

        {

            get

            {

                return ServicePlanId;

            }

            set

            {

                ServicePlanId = value;

            }

        }

        public AssignedPlan() : base()

        {

        }

    }

    public partial class ProvisionedPlan : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _capabilityStatus;

        private System.String _provisioningStatus;

        private System.String _service;

        public System.String CapabilityStatus

        {

            get

            {

                return _capabilityStatus;

            }

            set

            {

                if (value != _capabilityStatus)

                {

                    _capabilityStatus = value;

                    OnPropertyChanged("capabilityStatus");

                }

            }

        }

        public System.String ProvisioningStatus

        {

            get

            {

                return _provisioningStatus;

            }

            set

            {

                if (value != _provisioningStatus)

                {

                    _provisioningStatus = value;

                    OnPropertyChanged("provisioningStatus");

                }

            }

        }

        public System.String Service

        {

            get

            {

                return _service;

            }

            set

            {

                if (value != _service)

                {

                    _service = value;

                    OnPropertyChanged("service");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CapabilityStatus instead.")]

        public System.String capabilityStatus

        {

            get

            {

                return CapabilityStatus;

            }

            set

            {

                CapabilityStatus = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProvisioningStatus instead.")]

        public System.String provisioningStatus

        {

            get

            {

                return ProvisioningStatus;

            }

            set

            {

                ProvisioningStatus = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Service instead.")]

        public System.String service

        {

            get

            {

                return Service;

            }

            set

            {

                Service = value;

            }

        }

        public ProvisionedPlan() : base()

        {

        }

    }

    public partial class VerifiedDomain : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _capabilities;

        private System.Nullable<System.Boolean> _isDefault;

        private System.Nullable<System.Boolean> _isInitial;

        private System.String _name;

        private System.String _type;

        public System.String Capabilities

        {

            get

            {

                return _capabilities;

            }

            set

            {

                if (value != _capabilities)

                {

                    _capabilities = value;

                    OnPropertyChanged("capabilities");

                }

            }

        }

        public System.Nullable<System.Boolean> IsDefault

        {

            get

            {

                return _isDefault;

            }

            set

            {

                if (value != _isDefault)

                {

                    _isDefault = value;

                    OnPropertyChanged("isDefault");

                }

            }

        }

        public System.Nullable<System.Boolean> IsInitial

        {

            get

            {

                return _isInitial;

            }

            set

            {

                if (value != _isInitial)

                {

                    _isInitial = value;

                    OnPropertyChanged("isInitial");

                }

            }

        }

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Capabilities instead.")]

        public System.String capabilities

        {

            get

            {

                return Capabilities;

            }

            set

            {

                Capabilities = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsDefault instead.")]

        public System.Nullable<System.Boolean> isDefault

        {

            get

            {

                return IsDefault;

            }

            set

            {

                IsDefault = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsInitial instead.")]

        public System.Nullable<System.Boolean> isInitial

        {

            get

            {

                return IsInitial;

            }

            set

            {

                IsInitial = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        public VerifiedDomain() : base()

        {

        }

    }

    public partial class AssignedLicense : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.Guid> _disabledPlans;

        private System.Nullable<System.Guid> _skuId;

        public System.Collections.Generic.IList<System.Guid> DisabledPlans

        {

            get

            {

                if (this._disabledPlans == default(System.Collections.Generic.IList<System.Guid>))

                {

                    this._disabledPlans = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.Guid>();

                    this._disabledPlans.SetContainer(() => GetContainingEntity("disabledPlans"));

                }

                return this._disabledPlans;

            }

            set

            {

                DisabledPlans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        DisabledPlans.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.Guid> SkuId

        {

            get

            {

                return _skuId;

            }

            set

            {

                if (value != _skuId)

                {

                    _skuId = value;

                    OnPropertyChanged("skuId");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisabledPlans instead.")]

        public global::System.Collections.Generic.IList<System.Guid> disabledPlans

        {

            get

            {

                return DisabledPlans;

            }

            set

            {

                DisabledPlans = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SkuId instead.")]

        public System.Nullable<System.Guid> skuId

        {

            get

            {

                return SkuId;

            }

            set

            {

                SkuId = value;

            }

        }

        public AssignedLicense() : base()

        {

        }

    }

    public partial class PasswordProfile : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _password;

        private System.Nullable<System.Boolean> _forceChangePasswordNextSignIn;

        public System.String Password

        {

            get

            {

                return _password;

            }

            set

            {

                if (value != _password)

                {

                    _password = value;

                    OnPropertyChanged("password");

                }

            }

        }

        public System.Nullable<System.Boolean> ForceChangePasswordNextSignIn

        {

            get

            {

                return _forceChangePasswordNextSignIn;

            }

            set

            {

                if (value != _forceChangePasswordNextSignIn)

                {

                    _forceChangePasswordNextSignIn = value;

                    OnPropertyChanged("forceChangePasswordNextSignIn");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Password instead.")]

        public System.String password

        {

            get

            {

                return Password;

            }

            set

            {

                Password = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ForceChangePasswordNextSignIn instead.")]

        public System.Nullable<System.Boolean> forceChangePasswordNextSignIn

        {

            get

            {

                return ForceChangePasswordNextSignIn;

            }

            set

            {

                ForceChangePasswordNextSignIn = value;

            }

        }

        public PasswordProfile() : base()

        {

        }

    }

    public partial class Recipient : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.EmailAddress _emailAddress;

        public global::Microsoft.Graph.EmailAddress EmailAddress

        {

            get

            {

                return _emailAddress;

            }

            set

            {

                if (value != _emailAddress)

                {

                    _emailAddress = value;

                    OnPropertyChanged("emailAddress");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EmailAddress instead.")]

        public global::Microsoft.Graph.EmailAddress emailAddress

        {

            get

            {

                return EmailAddress;

            }

            set

            {

                EmailAddress = value;

            }

        }

        public Recipient() : base()

        {

        }

    }

    public partial class EmailAddress : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _name;

        private System.String _address;

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        public System.String Address

        {

            get

            {

                return _address;

            }

            set

            {

                if (value != _address)

                {

                    _address = value;

                    OnPropertyChanged("address");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Address instead.")]

        public System.String address

        {

            get

            {

                return Address;

            }

            set

            {

                Address = value;

            }

        }

        public EmailAddress() : base()

        {

        }

    }

    public partial class AttendeeBase : global::Microsoft.Graph.Recipient

    {

        private global::Microsoft.Graph.AttendeeType _type;

        public global::Microsoft.Graph.AttendeeType Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public global::Microsoft.Graph.AttendeeType type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        public AttendeeBase()

        {

        }

    }

    public partial class MeetingTimeCandidate : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.TimeSlot _meetingTimeSlot;

        private System.Nullable<System.Double> _confidence;

        private System.Nullable<System.Int32> _score;

        private global::Microsoft.Graph.FreeBusyStatus _organizerAvailability;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AttendeeAvailability> _attendeeAvailability;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Location> _locations;

        public global::Microsoft.Graph.TimeSlot MeetingTimeSlot

        {

            get

            {

                return _meetingTimeSlot;

            }

            set

            {

                if (value != _meetingTimeSlot)

                {

                    _meetingTimeSlot = value;

                    OnPropertyChanged("meetingTimeSlot");

                }

            }

        }

        public System.Nullable<System.Double> Confidence

        {

            get

            {

                return _confidence;

            }

            set

            {

                if (value != _confidence)

                {

                    _confidence = value;

                    OnPropertyChanged("confidence");

                }

            }

        }

        public System.Nullable<System.Int32> Score

        {

            get

            {

                return _score;

            }

            set

            {

                if (value != _score)

                {

                    _score = value;

                    OnPropertyChanged("score");

                }

            }

        }

        public global::Microsoft.Graph.FreeBusyStatus OrganizerAvailability

        {

            get

            {

                return _organizerAvailability;

            }

            set

            {

                if (value != _organizerAvailability)

                {

                    _organizerAvailability = value;

                    OnPropertyChanged("organizerAvailability");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AttendeeAvailability> AttendeeAvailability

        {

            get

            {

                if (this._attendeeAvailability == default(System.Collections.Generic.IList<global::Microsoft.Graph.AttendeeAvailability>))

                {

                    this._attendeeAvailability = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AttendeeAvailability>();

                    this._attendeeAvailability.SetContainer(() => GetContainingEntity("attendeeAvailability"));

                }

                return this._attendeeAvailability;

            }

            set

            {

                AttendeeAvailability.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AttendeeAvailability.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Location> Locations

        {

            get

            {

                if (this._locations == default(System.Collections.Generic.IList<global::Microsoft.Graph.Location>))

                {

                    this._locations = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Location>();

                    this._locations.SetContainer(() => GetContainingEntity("locations"));

                }

                return this._locations;

            }

            set

            {

                Locations.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Locations.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MeetingTimeSlot instead.")]

        public global::Microsoft.Graph.TimeSlot meetingTimeSlot

        {

            get

            {

                return MeetingTimeSlot;

            }

            set

            {

                MeetingTimeSlot = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Confidence instead.")]

        public System.Nullable<System.Double> confidence

        {

            get

            {

                return Confidence;

            }

            set

            {

                Confidence = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Score instead.")]

        public System.Nullable<System.Int32> score

        {

            get

            {

                return Score;

            }

            set

            {

                Score = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OrganizerAvailability instead.")]

        public global::Microsoft.Graph.FreeBusyStatus organizerAvailability

        {

            get

            {

                return OrganizerAvailability;

            }

            set

            {

                OrganizerAvailability = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AttendeeAvailability instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AttendeeAvailability> attendeeAvailability

        {

            get

            {

                return AttendeeAvailability;

            }

            set

            {

                AttendeeAvailability = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Locations instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Location> locations

        {

            get

            {

                return Locations;

            }

            set

            {

                Locations = value;

            }

        }

        public MeetingTimeCandidate() : base()

        {

        }

    }

    public partial class TimeSlot : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.TimeStamp _start;

        private global::Microsoft.Graph.TimeStamp _end;

        public global::Microsoft.Graph.TimeStamp Start

        {

            get

            {

                return _start;

            }

            set

            {

                if (value != _start)

                {

                    _start = value;

                    OnPropertyChanged("start");

                }

            }

        }

        public global::Microsoft.Graph.TimeStamp End

        {

            get

            {

                return _end;

            }

            set

            {

                if (value != _end)

                {

                    _end = value;

                    OnPropertyChanged("end");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Start instead.")]

        public global::Microsoft.Graph.TimeStamp start

        {

            get

            {

                return Start;

            }

            set

            {

                Start = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use End instead.")]

        public global::Microsoft.Graph.TimeStamp end

        {

            get

            {

                return End;

            }

            set

            {

                End = value;

            }

        }

        public TimeSlot() : base()

        {

        }

    }

    public partial class TimeStamp : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.DateTimeOffset> _date;

        private System.Nullable<System.DateTimeOffset> _time;

        private System.String _timeZone;

        public System.Nullable<System.DateTimeOffset> Date

        {

            get

            {

                return _date;

            }

            set

            {

                if (value != _date)

                {

                    _date = value;

                    OnPropertyChanged("date");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> Time

        {

            get

            {

                return _time;

            }

            set

            {

                if (value != _time)

                {

                    _time = value;

                    OnPropertyChanged("time");

                }

            }

        }

        public System.String TimeZone

        {

            get

            {

                return _timeZone;

            }

            set

            {

                if (value != _timeZone)

                {

                    _timeZone = value;

                    OnPropertyChanged("timeZone");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Date instead.")]

        public System.Nullable<System.DateTimeOffset> date

        {

            get

            {

                return Date;

            }

            set

            {

                Date = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Time instead.")]

        public System.Nullable<System.DateTimeOffset> time

        {

            get

            {

                return Time;

            }

            set

            {

                Time = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TimeZone instead.")]

        public System.String timeZone

        {

            get

            {

                return TimeZone;

            }

            set

            {

                TimeZone = value;

            }

        }

        public TimeStamp() : base()

        {

        }

    }

    public partial class AttendeeAvailability : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.AttendeeBase _attendee;

        private global::Microsoft.Graph.FreeBusyStatus _availability;

        public global::Microsoft.Graph.AttendeeBase Attendee

        {

            get

            {

                return _attendee;

            }

            set

            {

                if (value != _attendee)

                {

                    _attendee = value;

                    OnPropertyChanged("attendee");

                }

            }

        }

        public global::Microsoft.Graph.FreeBusyStatus Availability

        {

            get

            {

                return _availability;

            }

            set

            {

                if (value != _availability)

                {

                    _availability = value;

                    OnPropertyChanged("availability");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Attendee instead.")]

        public global::Microsoft.Graph.AttendeeBase attendee

        {

            get

            {

                return Attendee;

            }

            set

            {

                Attendee = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Availability instead.")]

        public global::Microsoft.Graph.FreeBusyStatus availability

        {

            get

            {

                return Availability;

            }

            set

            {

                Availability = value;

            }

        }

        public AttendeeAvailability() : base()

        {

        }

    }

    public partial class Location : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _displayName;

        private System.String _locationEmailAddress;

        private global::Microsoft.Graph.PhysicalAddress _address;

        private global::Microsoft.Graph.OutlookGeoCoordinates _coordinates;

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String LocationEmailAddress

        {

            get

            {

                return _locationEmailAddress;

            }

            set

            {

                if (value != _locationEmailAddress)

                {

                    _locationEmailAddress = value;

                    OnPropertyChanged("locationEmailAddress");

                }

            }

        }

        public global::Microsoft.Graph.PhysicalAddress Address

        {

            get

            {

                return _address;

            }

            set

            {

                if (value != _address)

                {

                    _address = value;

                    OnPropertyChanged("address");

                }

            }

        }

        public global::Microsoft.Graph.OutlookGeoCoordinates Coordinates

        {

            get

            {

                return _coordinates;

            }

            set

            {

                if (value != _coordinates)

                {

                    _coordinates = value;

                    OnPropertyChanged("coordinates");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LocationEmailAddress instead.")]

        public System.String locationEmailAddress

        {

            get

            {

                return LocationEmailAddress;

            }

            set

            {

                LocationEmailAddress = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Address instead.")]

        public global::Microsoft.Graph.PhysicalAddress address

        {

            get

            {

                return Address;

            }

            set

            {

                Address = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Coordinates instead.")]

        public global::Microsoft.Graph.OutlookGeoCoordinates coordinates

        {

            get

            {

                return Coordinates;

            }

            set

            {

                Coordinates = value;

            }

        }

        public Location() : base()

        {

        }

    }

    public partial class PhysicalAddress : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _street;

        private System.String _city;

        private System.String _state;

        private System.String _countryOrRegion;

        private System.String _postalCode;

        public System.String Street

        {

            get

            {

                return _street;

            }

            set

            {

                if (value != _street)

                {

                    _street = value;

                    OnPropertyChanged("street");

                }

            }

        }

        public System.String City

        {

            get

            {

                return _city;

            }

            set

            {

                if (value != _city)

                {

                    _city = value;

                    OnPropertyChanged("city");

                }

            }

        }

        public System.String State

        {

            get

            {

                return _state;

            }

            set

            {

                if (value != _state)

                {

                    _state = value;

                    OnPropertyChanged("state");

                }

            }

        }

        public System.String CountryOrRegion

        {

            get

            {

                return _countryOrRegion;

            }

            set

            {

                if (value != _countryOrRegion)

                {

                    _countryOrRegion = value;

                    OnPropertyChanged("countryOrRegion");

                }

            }

        }

        public System.String PostalCode

        {

            get

            {

                return _postalCode;

            }

            set

            {

                if (value != _postalCode)

                {

                    _postalCode = value;

                    OnPropertyChanged("postalCode");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Street instead.")]

        public System.String street

        {

            get

            {

                return Street;

            }

            set

            {

                Street = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use City instead.")]

        public System.String city

        {

            get

            {

                return City;

            }

            set

            {

                City = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use State instead.")]

        public System.String state

        {

            get

            {

                return State;

            }

            set

            {

                State = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CountryOrRegion instead.")]

        public System.String countryOrRegion

        {

            get

            {

                return CountryOrRegion;

            }

            set

            {

                CountryOrRegion = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PostalCode instead.")]

        public System.String postalCode

        {

            get

            {

                return PostalCode;

            }

            set

            {

                PostalCode = value;

            }

        }

        public PhysicalAddress() : base()

        {

        }

    }

    public partial class OutlookGeoCoordinates : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Double> _altitude;

        private System.Nullable<System.Double> _latitude;

        private System.Nullable<System.Double> _longitude;

        private System.Nullable<System.Double> _accuracy;

        private System.Nullable<System.Double> _altitudeAccuracy;

        public System.Nullable<System.Double> Altitude

        {

            get

            {

                return _altitude;

            }

            set

            {

                if (value != _altitude)

                {

                    _altitude = value;

                    OnPropertyChanged("altitude");

                }

            }

        }

        public System.Nullable<System.Double> Latitude

        {

            get

            {

                return _latitude;

            }

            set

            {

                if (value != _latitude)

                {

                    _latitude = value;

                    OnPropertyChanged("latitude");

                }

            }

        }

        public System.Nullable<System.Double> Longitude

        {

            get

            {

                return _longitude;

            }

            set

            {

                if (value != _longitude)

                {

                    _longitude = value;

                    OnPropertyChanged("longitude");

                }

            }

        }

        public System.Nullable<System.Double> Accuracy

        {

            get

            {

                return _accuracy;

            }

            set

            {

                if (value != _accuracy)

                {

                    _accuracy = value;

                    OnPropertyChanged("accuracy");

                }

            }

        }

        public System.Nullable<System.Double> AltitudeAccuracy

        {

            get

            {

                return _altitudeAccuracy;

            }

            set

            {

                if (value != _altitudeAccuracy)

                {

                    _altitudeAccuracy = value;

                    OnPropertyChanged("altitudeAccuracy");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Altitude instead.")]

        public System.Nullable<System.Double> altitude

        {

            get

            {

                return Altitude;

            }

            set

            {

                Altitude = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Latitude instead.")]

        public System.Nullable<System.Double> latitude

        {

            get

            {

                return Latitude;

            }

            set

            {

                Latitude = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Longitude instead.")]

        public System.Nullable<System.Double> longitude

        {

            get

            {

                return Longitude;

            }

            set

            {

                Longitude = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Accuracy instead.")]

        public System.Nullable<System.Double> accuracy

        {

            get

            {

                return Accuracy;

            }

            set

            {

                Accuracy = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AltitudeAccuracy instead.")]

        public System.Nullable<System.Double> altitudeAccuracy

        {

            get

            {

                return AltitudeAccuracy;

            }

            set

            {

                AltitudeAccuracy = value;

            }

        }

        public OutlookGeoCoordinates() : base()

        {

        }

    }

    public partial class LocationConstraint : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Boolean> _isRequired;

        private System.Nullable<System.Boolean> _suggestLocation;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Location> _locations;

        public System.Nullable<System.Boolean> IsRequired

        {

            get

            {

                return _isRequired;

            }

            set

            {

                if (value != _isRequired)

                {

                    _isRequired = value;

                    OnPropertyChanged("isRequired");

                }

            }

        }

        public System.Nullable<System.Boolean> SuggestLocation

        {

            get

            {

                return _suggestLocation;

            }

            set

            {

                if (value != _suggestLocation)

                {

                    _suggestLocation = value;

                    OnPropertyChanged("suggestLocation");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Location> Locations

        {

            get

            {

                if (this._locations == default(System.Collections.Generic.IList<global::Microsoft.Graph.Location>))

                {

                    this._locations = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Location>();

                    this._locations.SetContainer(() => GetContainingEntity("locations"));

                }

                return this._locations;

            }

            set

            {

                Locations.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Locations.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsRequired instead.")]

        public System.Nullable<System.Boolean> isRequired

        {

            get

            {

                return IsRequired;

            }

            set

            {

                IsRequired = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SuggestLocation instead.")]

        public System.Nullable<System.Boolean> suggestLocation

        {

            get

            {

                return SuggestLocation;

            }

            set

            {

                SuggestLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Locations instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Location> locations

        {

            get

            {

                return Locations;

            }

            set

            {

                Locations = value;

            }

        }

        public LocationConstraint() : base()

        {

        }

    }

    public partial class TimeConstraint : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.ActivityDomain _activityDomain;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.TimeSlot> _timeslots;

        public global::Microsoft.Graph.ActivityDomain ActivityDomain

        {

            get

            {

                return _activityDomain;

            }

            set

            {

                if (value != _activityDomain)

                {

                    _activityDomain = value;

                    OnPropertyChanged("activityDomain");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.TimeSlot> Timeslots

        {

            get

            {

                if (this._timeslots == default(System.Collections.Generic.IList<global::Microsoft.Graph.TimeSlot>))

                {

                    this._timeslots = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.TimeSlot>();

                    this._timeslots.SetContainer(() => GetContainingEntity("timeslots"));

                }

                return this._timeslots;

            }

            set

            {

                Timeslots.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Timeslots.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ActivityDomain instead.")]

        public global::Microsoft.Graph.ActivityDomain activityDomain

        {

            get

            {

                return ActivityDomain;

            }

            set

            {

                ActivityDomain = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Timeslots instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.TimeSlot> timeslots

        {

            get

            {

                return Timeslots;

            }

            set

            {

                Timeslots = value;

            }

        }

        public TimeConstraint() : base()

        {

        }

    }

    public partial class Reminder : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _eventId;

        private global::Microsoft.Graph.DateTimeTimeZone _eventStartTime;

        private global::Microsoft.Graph.DateTimeTimeZone _eventEndTime;

        private System.String _changeKey;

        private System.String _eventSubject;

        private global::Microsoft.Graph.Location _eventLocation;

        private System.String _eventWebLink;

        private global::Microsoft.Graph.DateTimeTimeZone _reminderFireTime;

        public System.String EventId

        {

            get

            {

                return _eventId;

            }

            set

            {

                if (value != _eventId)

                {

                    _eventId = value;

                    OnPropertyChanged("eventId");

                }

            }

        }

        public global::Microsoft.Graph.DateTimeTimeZone EventStartTime

        {

            get

            {

                return _eventStartTime;

            }

            set

            {

                if (value != _eventStartTime)

                {

                    _eventStartTime = value;

                    OnPropertyChanged("eventStartTime");

                }

            }

        }

        public global::Microsoft.Graph.DateTimeTimeZone EventEndTime

        {

            get

            {

                return _eventEndTime;

            }

            set

            {

                if (value != _eventEndTime)

                {

                    _eventEndTime = value;

                    OnPropertyChanged("eventEndTime");

                }

            }

        }

        public System.String ChangeKey

        {

            get

            {

                return _changeKey;

            }

            set

            {

                if (value != _changeKey)

                {

                    _changeKey = value;

                    OnPropertyChanged("changeKey");

                }

            }

        }

        public System.String EventSubject

        {

            get

            {

                return _eventSubject;

            }

            set

            {

                if (value != _eventSubject)

                {

                    _eventSubject = value;

                    OnPropertyChanged("eventSubject");

                }

            }

        }

        public global::Microsoft.Graph.Location EventLocation

        {

            get

            {

                return _eventLocation;

            }

            set

            {

                if (value != _eventLocation)

                {

                    _eventLocation = value;

                    OnPropertyChanged("eventLocation");

                }

            }

        }

        public System.String EventWebLink

        {

            get

            {

                return _eventWebLink;

            }

            set

            {

                if (value != _eventWebLink)

                {

                    _eventWebLink = value;

                    OnPropertyChanged("eventWebLink");

                }

            }

        }

        public global::Microsoft.Graph.DateTimeTimeZone ReminderFireTime

        {

            get

            {

                return _reminderFireTime;

            }

            set

            {

                if (value != _reminderFireTime)

                {

                    _reminderFireTime = value;

                    OnPropertyChanged("reminderFireTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EventId instead.")]

        public System.String eventId

        {

            get

            {

                return EventId;

            }

            set

            {

                EventId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EventStartTime instead.")]

        public global::Microsoft.Graph.DateTimeTimeZone eventStartTime

        {

            get

            {

                return EventStartTime;

            }

            set

            {

                EventStartTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EventEndTime instead.")]

        public global::Microsoft.Graph.DateTimeTimeZone eventEndTime

        {

            get

            {

                return EventEndTime;

            }

            set

            {

                EventEndTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChangeKey instead.")]

        public System.String changeKey

        {

            get

            {

                return ChangeKey;

            }

            set

            {

                ChangeKey = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EventSubject instead.")]

        public System.String eventSubject

        {

            get

            {

                return EventSubject;

            }

            set

            {

                EventSubject = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EventLocation instead.")]

        public global::Microsoft.Graph.Location eventLocation

        {

            get

            {

                return EventLocation;

            }

            set

            {

                EventLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EventWebLink instead.")]

        public System.String eventWebLink

        {

            get

            {

                return EventWebLink;

            }

            set

            {

                EventWebLink = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ReminderFireTime instead.")]

        public global::Microsoft.Graph.DateTimeTimeZone reminderFireTime

        {

            get

            {

                return ReminderFireTime;

            }

            set

            {

                ReminderFireTime = value;

            }

        }

        public Reminder() : base()

        {

        }

    }

    public partial class DateTimeTimeZone : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _dateTime;

        private System.String _timeZone;

        public System.String DateTime

        {

            get

            {

                return _dateTime;

            }

            set

            {

                if (value != _dateTime)

                {

                    _dateTime = value;

                    OnPropertyChanged("dateTime");

                }

            }

        }

        public System.String TimeZone

        {

            get

            {

                return _timeZone;

            }

            set

            {

                if (value != _timeZone)

                {

                    _timeZone = value;

                    OnPropertyChanged("timeZone");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DateTime instead.")]

        public System.String dateTime

        {

            get

            {

                return DateTime;

            }

            set

            {

                DateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TimeZone instead.")]

        public System.String timeZone

        {

            get

            {

                return TimeZone;

            }

            set

            {

                TimeZone = value;

            }

        }

        public DateTimeTimeZone() : base()

        {

        }

    }

    public partial class ItemBody : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.BodyType _contentType;

        private System.String _content;

        public global::Microsoft.Graph.BodyType ContentType

        {

            get

            {

                return _contentType;

            }

            set

            {

                if (value != _contentType)

                {

                    _contentType = value;

                    OnPropertyChanged("contentType");

                }

            }

        }

        public System.String Content

        {

            get

            {

                return _content;

            }

            set

            {

                if (value != _content)

                {

                    _content = value;

                    OnPropertyChanged("content");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ContentType instead.")]

        public global::Microsoft.Graph.BodyType contentType

        {

            get

            {

                return ContentType;

            }

            set

            {

                ContentType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Content instead.")]

        public System.String content

        {

            get

            {

                return Content;

            }

            set

            {

                Content = value;

            }

        }

        public ItemBody() : base()

        {

        }

    }

    public partial class ResponseStatus : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.ResponseType _response;

        private System.Nullable<System.DateTimeOffset> _time;

        public global::Microsoft.Graph.ResponseType Response

        {

            get

            {

                return _response;

            }

            set

            {

                if (value != _response)

                {

                    _response = value;

                    OnPropertyChanged("response");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> Time

        {

            get

            {

                return _time;

            }

            set

            {

                if (value != _time)

                {

                    _time = value;

                    OnPropertyChanged("time");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Response instead.")]

        public global::Microsoft.Graph.ResponseType response

        {

            get

            {

                return Response;

            }

            set

            {

                Response = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Time instead.")]

        public System.Nullable<System.DateTimeOffset> time

        {

            get

            {

                return Time;

            }

            set

            {

                Time = value;

            }

        }

        public ResponseStatus() : base()

        {

        }

    }

    public partial class PatternedRecurrence : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.RecurrencePattern _pattern;

        private global::Microsoft.Graph.RecurrenceRange _range;

        public global::Microsoft.Graph.RecurrencePattern Pattern

        {

            get

            {

                return _pattern;

            }

            set

            {

                if (value != _pattern)

                {

                    _pattern = value;

                    OnPropertyChanged("pattern");

                }

            }

        }

        public global::Microsoft.Graph.RecurrenceRange Range

        {

            get

            {

                return _range;

            }

            set

            {

                if (value != _range)

                {

                    _range = value;

                    OnPropertyChanged("range");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Pattern instead.")]

        public global::Microsoft.Graph.RecurrencePattern pattern

        {

            get

            {

                return Pattern;

            }

            set

            {

                Pattern = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Range instead.")]

        public global::Microsoft.Graph.RecurrenceRange range

        {

            get

            {

                return Range;

            }

            set

            {

                Range = value;

            }

        }

        public PatternedRecurrence() : base()

        {

        }

    }

    public partial class RecurrencePattern : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.RecurrencePatternType _type;

        private System.Int32 _interval;

        private System.Int32 _month;

        private System.Int32 _dayOfMonth;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.DayOfWeek> _daysOfWeek;

        private global::Microsoft.Graph.DayOfWeek _firstDayOfWeek;

        private global::Microsoft.Graph.WeekIndex _index;

        public global::Microsoft.Graph.RecurrencePatternType Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.Int32 Interval

        {

            get

            {

                return _interval;

            }

            set

            {

                if (value != _interval)

                {

                    _interval = value;

                    OnPropertyChanged("interval");

                }

            }

        }

        public System.Int32 Month

        {

            get

            {

                return _month;

            }

            set

            {

                if (value != _month)

                {

                    _month = value;

                    OnPropertyChanged("month");

                }

            }

        }

        public System.Int32 DayOfMonth

        {

            get

            {

                return _dayOfMonth;

            }

            set

            {

                if (value != _dayOfMonth)

                {

                    _dayOfMonth = value;

                    OnPropertyChanged("dayOfMonth");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.DayOfWeek> DaysOfWeek

        {

            get

            {

                if (this._daysOfWeek == default(System.Collections.Generic.IList<global::Microsoft.Graph.DayOfWeek>))

                {

                    this._daysOfWeek = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.DayOfWeek>();

                    this._daysOfWeek.SetContainer(() => GetContainingEntity("daysOfWeek"));

                }

                return this._daysOfWeek;

            }

            set

            {

                DaysOfWeek.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        DaysOfWeek.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.DayOfWeek FirstDayOfWeek

        {

            get

            {

                return _firstDayOfWeek;

            }

            set

            {

                if (value != _firstDayOfWeek)

                {

                    _firstDayOfWeek = value;

                    OnPropertyChanged("firstDayOfWeek");

                }

            }

        }

        public global::Microsoft.Graph.WeekIndex Index

        {

            get

            {

                return _index;

            }

            set

            {

                if (value != _index)

                {

                    _index = value;

                    OnPropertyChanged("index");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public global::Microsoft.Graph.RecurrencePatternType type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Interval instead.")]

        public System.Int32 interval

        {

            get

            {

                return Interval;

            }

            set

            {

                Interval = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Month instead.")]

        public System.Int32 month

        {

            get

            {

                return Month;

            }

            set

            {

                Month = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DayOfMonth instead.")]

        public System.Int32 dayOfMonth

        {

            get

            {

                return DayOfMonth;

            }

            set

            {

                DayOfMonth = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DaysOfWeek instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DayOfWeek> daysOfWeek

        {

            get

            {

                return DaysOfWeek;

            }

            set

            {

                DaysOfWeek = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use FirstDayOfWeek instead.")]

        public global::Microsoft.Graph.DayOfWeek firstDayOfWeek

        {

            get

            {

                return FirstDayOfWeek;

            }

            set

            {

                FirstDayOfWeek = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Index instead.")]

        public global::Microsoft.Graph.WeekIndex index

        {

            get

            {

                return Index;

            }

            set

            {

                Index = value;

            }

        }

        public RecurrencePattern() : base()

        {

        }

    }

    public partial class RecurrenceRange : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.RecurrenceRangeType _type;

        private System.Nullable<System.DateTimeOffset> _startDate;

        private System.Nullable<System.DateTimeOffset> _endDate;

        private System.String _recurrenceTimeZone;

        private System.Int32 _numberOfOccurrences;

        public global::Microsoft.Graph.RecurrenceRangeType Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> StartDate

        {

            get

            {

                return _startDate;

            }

            set

            {

                if (value != _startDate)

                {

                    _startDate = value;

                    OnPropertyChanged("startDate");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> EndDate

        {

            get

            {

                return _endDate;

            }

            set

            {

                if (value != _endDate)

                {

                    _endDate = value;

                    OnPropertyChanged("endDate");

                }

            }

        }

        public System.String RecurrenceTimeZone

        {

            get

            {

                return _recurrenceTimeZone;

            }

            set

            {

                if (value != _recurrenceTimeZone)

                {

                    _recurrenceTimeZone = value;

                    OnPropertyChanged("recurrenceTimeZone");

                }

            }

        }

        public System.Int32 NumberOfOccurrences

        {

            get

            {

                return _numberOfOccurrences;

            }

            set

            {

                if (value != _numberOfOccurrences)

                {

                    _numberOfOccurrences = value;

                    OnPropertyChanged("numberOfOccurrences");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public global::Microsoft.Graph.RecurrenceRangeType type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use StartDate instead.")]

        public System.Nullable<System.DateTimeOffset> startDate

        {

            get

            {

                return StartDate;

            }

            set

            {

                StartDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EndDate instead.")]

        public System.Nullable<System.DateTimeOffset> endDate

        {

            get

            {

                return EndDate;

            }

            set

            {

                EndDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RecurrenceTimeZone instead.")]

        public System.String recurrenceTimeZone

        {

            get

            {

                return RecurrenceTimeZone;

            }

            set

            {

                RecurrenceTimeZone = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use NumberOfOccurrences instead.")]

        public System.Int32 numberOfOccurrences

        {

            get

            {

                return NumberOfOccurrences;

            }

            set

            {

                NumberOfOccurrences = value;

            }

        }

        public RecurrenceRange() : base()

        {

        }

    }

    public partial class Attendee : global::Microsoft.Graph.AttendeeBase

    {

        private global::Microsoft.Graph.ResponseStatus _status;

        public global::Microsoft.Graph.ResponseStatus Status

        {

            get

            {

                return _status;

            }

            set

            {

                if (value != _status)

                {

                    _status = value;

                    OnPropertyChanged("status");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Status instead.")]

        public global::Microsoft.Graph.ResponseStatus status

        {

            get

            {

                return Status;

            }

            set

            {

                Status = value;

            }

        }

        public Attendee()

        {

        }

    }

    public partial class PersonDataSource : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _type;

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        public PersonDataSource() : base()

        {

        }

    }

    public partial class Email : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _address;

        public System.String Address

        {

            get

            {

                return _address;

            }

            set

            {

                if (value != _address)

                {

                    _address = value;

                    OnPropertyChanged("address");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Address instead.")]

        public System.String address

        {

            get

            {

                return Address;

            }

            set

            {

                Address = value;

            }

        }

        public Email() : base()

        {

        }

    }

    public partial class IdentitySet : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.Identity _application;

        private global::Microsoft.Graph.Identity _device;

        private global::Microsoft.Graph.Identity _user;

        public global::Microsoft.Graph.Identity Application

        {

            get

            {

                return _application;

            }

            set

            {

                if (value != _application)

                {

                    _application = value;

                    OnPropertyChanged("application");

                }

            }

        }

        public global::Microsoft.Graph.Identity Device

        {

            get

            {

                return _device;

            }

            set

            {

                if (value != _device)

                {

                    _device = value;

                    OnPropertyChanged("device");

                }

            }

        }

        public global::Microsoft.Graph.Identity User

        {

            get

            {

                return _user;

            }

            set

            {

                if (value != _user)

                {

                    _user = value;

                    OnPropertyChanged("user");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Application instead.")]

        public global::Microsoft.Graph.Identity application

        {

            get

            {

                return Application;

            }

            set

            {

                Application = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Device instead.")]

        public global::Microsoft.Graph.Identity device

        {

            get

            {

                return Device;

            }

            set

            {

                Device = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use User instead.")]

        public global::Microsoft.Graph.Identity user

        {

            get

            {

                return User;

            }

            set

            {

                User = value;

            }

        }

        public IdentitySet() : base()

        {

        }

    }

    public partial class Identity : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _displayName;

        private System.String _id;

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        public Identity() : base()

        {

        }

    }

    public partial class Quota : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Int64> _deleted;

        private System.Nullable<System.Int64> _remaining;

        private System.String _state;

        private System.Nullable<System.Int64> _total;

        private System.Nullable<System.Int64> _used;

        public System.Nullable<System.Int64> Deleted

        {

            get

            {

                return _deleted;

            }

            set

            {

                if (value != _deleted)

                {

                    _deleted = value;

                    OnPropertyChanged("deleted");

                }

            }

        }

        public System.Nullable<System.Int64> Remaining

        {

            get

            {

                return _remaining;

            }

            set

            {

                if (value != _remaining)

                {

                    _remaining = value;

                    OnPropertyChanged("remaining");

                }

            }

        }

        public System.String State

        {

            get

            {

                return _state;

            }

            set

            {

                if (value != _state)

                {

                    _state = value;

                    OnPropertyChanged("state");

                }

            }

        }

        public System.Nullable<System.Int64> Total

        {

            get

            {

                return _total;

            }

            set

            {

                if (value != _total)

                {

                    _total = value;

                    OnPropertyChanged("total");

                }

            }

        }

        public System.Nullable<System.Int64> Used

        {

            get

            {

                return _used;

            }

            set

            {

                if (value != _used)

                {

                    _used = value;

                    OnPropertyChanged("used");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Deleted instead.")]

        public System.Nullable<System.Int64> deleted

        {

            get

            {

                return Deleted;

            }

            set

            {

                Deleted = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Remaining instead.")]

        public System.Nullable<System.Int64> remaining

        {

            get

            {

                return Remaining;

            }

            set

            {

                Remaining = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use State instead.")]

        public System.String state

        {

            get

            {

                return State;

            }

            set

            {

                State = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Total instead.")]

        public System.Nullable<System.Int64> total

        {

            get

            {

                return Total;

            }

            set

            {

                Total = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Used instead.")]

        public System.Nullable<System.Int64> used

        {

            get

            {

                return Used;

            }

            set

            {

                Used = value;

            }

        }

        public Quota() : base()

        {

        }

    }

    public partial class ItemReference : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _driveId;

        private System.String _id;

        private System.String _path;

        public System.String DriveId

        {

            get

            {

                return _driveId;

            }

            set

            {

                if (value != _driveId)

                {

                    _driveId = value;

                    OnPropertyChanged("driveId");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String Path

        {

            get

            {

                return _path;

            }

            set

            {

                if (value != _path)

                {

                    _path = value;

                    OnPropertyChanged("path");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DriveId instead.")]

        public System.String driveId

        {

            get

            {

                return DriveId;

            }

            set

            {

                DriveId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Path instead.")]

        public System.String path

        {

            get

            {

                return Path;

            }

            set

            {

                Path = value;

            }

        }

        public ItemReference() : base()

        {

        }

    }

    public partial class Audio : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _album;

        private System.String _albumArtist;

        private System.String _artist;

        private System.Nullable<System.Int64> _bitrate;

        private System.String _composers;

        private System.String _copyright;

        private System.Nullable<System.Int16> _disc;

        private System.Nullable<System.Int16> _discCount;

        private System.Nullable<System.Int64> _duration;

        private System.String _genre;

        private System.Nullable<System.Boolean> _hasDrm;

        private System.Nullable<System.Boolean> _isVariableBitrate;

        private System.String _title;

        private System.Nullable<System.Int32> _track;

        private System.Nullable<System.Int32> _trackCount;

        private System.Nullable<System.Int32> _year;

        public System.String Album

        {

            get

            {

                return _album;

            }

            set

            {

                if (value != _album)

                {

                    _album = value;

                    OnPropertyChanged("album");

                }

            }

        }

        public System.String AlbumArtist

        {

            get

            {

                return _albumArtist;

            }

            set

            {

                if (value != _albumArtist)

                {

                    _albumArtist = value;

                    OnPropertyChanged("albumArtist");

                }

            }

        }

        public System.String Artist

        {

            get

            {

                return _artist;

            }

            set

            {

                if (value != _artist)

                {

                    _artist = value;

                    OnPropertyChanged("artist");

                }

            }

        }

        public System.Nullable<System.Int64> Bitrate

        {

            get

            {

                return _bitrate;

            }

            set

            {

                if (value != _bitrate)

                {

                    _bitrate = value;

                    OnPropertyChanged("bitrate");

                }

            }

        }

        public System.String Composers

        {

            get

            {

                return _composers;

            }

            set

            {

                if (value != _composers)

                {

                    _composers = value;

                    OnPropertyChanged("composers");

                }

            }

        }

        public System.String Copyright

        {

            get

            {

                return _copyright;

            }

            set

            {

                if (value != _copyright)

                {

                    _copyright = value;

                    OnPropertyChanged("copyright");

                }

            }

        }

        public System.Nullable<System.Int16> Disc

        {

            get

            {

                return _disc;

            }

            set

            {

                if (value != _disc)

                {

                    _disc = value;

                    OnPropertyChanged("disc");

                }

            }

        }

        public System.Nullable<System.Int16> DiscCount

        {

            get

            {

                return _discCount;

            }

            set

            {

                if (value != _discCount)

                {

                    _discCount = value;

                    OnPropertyChanged("discCount");

                }

            }

        }

        public System.Nullable<System.Int64> Duration

        {

            get

            {

                return _duration;

            }

            set

            {

                if (value != _duration)

                {

                    _duration = value;

                    OnPropertyChanged("duration");

                }

            }

        }

        public System.String Genre

        {

            get

            {

                return _genre;

            }

            set

            {

                if (value != _genre)

                {

                    _genre = value;

                    OnPropertyChanged("genre");

                }

            }

        }

        public System.Nullable<System.Boolean> HasDrm

        {

            get

            {

                return _hasDrm;

            }

            set

            {

                if (value != _hasDrm)

                {

                    _hasDrm = value;

                    OnPropertyChanged("hasDrm");

                }

            }

        }

        public System.Nullable<System.Boolean> IsVariableBitrate

        {

            get

            {

                return _isVariableBitrate;

            }

            set

            {

                if (value != _isVariableBitrate)

                {

                    _isVariableBitrate = value;

                    OnPropertyChanged("isVariableBitrate");

                }

            }

        }

        public System.String Title

        {

            get

            {

                return _title;

            }

            set

            {

                if (value != _title)

                {

                    _title = value;

                    OnPropertyChanged("title");

                }

            }

        }

        public System.Nullable<System.Int32> Track

        {

            get

            {

                return _track;

            }

            set

            {

                if (value != _track)

                {

                    _track = value;

                    OnPropertyChanged("track");

                }

            }

        }

        public System.Nullable<System.Int32> TrackCount

        {

            get

            {

                return _trackCount;

            }

            set

            {

                if (value != _trackCount)

                {

                    _trackCount = value;

                    OnPropertyChanged("trackCount");

                }

            }

        }

        public System.Nullable<System.Int32> Year

        {

            get

            {

                return _year;

            }

            set

            {

                if (value != _year)

                {

                    _year = value;

                    OnPropertyChanged("year");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Album instead.")]

        public System.String album

        {

            get

            {

                return Album;

            }

            set

            {

                Album = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AlbumArtist instead.")]

        public System.String albumArtist

        {

            get

            {

                return AlbumArtist;

            }

            set

            {

                AlbumArtist = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Artist instead.")]

        public System.String artist

        {

            get

            {

                return Artist;

            }

            set

            {

                Artist = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Bitrate instead.")]

        public System.Nullable<System.Int64> bitrate

        {

            get

            {

                return Bitrate;

            }

            set

            {

                Bitrate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Composers instead.")]

        public System.String composers

        {

            get

            {

                return Composers;

            }

            set

            {

                Composers = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Copyright instead.")]

        public System.String copyright

        {

            get

            {

                return Copyright;

            }

            set

            {

                Copyright = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Disc instead.")]

        public System.Nullable<System.Int16> disc

        {

            get

            {

                return Disc;

            }

            set

            {

                Disc = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DiscCount instead.")]

        public System.Nullable<System.Int16> discCount

        {

            get

            {

                return DiscCount;

            }

            set

            {

                DiscCount = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Duration instead.")]

        public System.Nullable<System.Int64> duration

        {

            get

            {

                return Duration;

            }

            set

            {

                Duration = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Genre instead.")]

        public System.String genre

        {

            get

            {

                return Genre;

            }

            set

            {

                Genre = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HasDrm instead.")]

        public System.Nullable<System.Boolean> hasDrm

        {

            get

            {

                return HasDrm;

            }

            set

            {

                HasDrm = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsVariableBitrate instead.")]

        public System.Nullable<System.Boolean> isVariableBitrate

        {

            get

            {

                return IsVariableBitrate;

            }

            set

            {

                IsVariableBitrate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Title instead.")]

        public System.String title

        {

            get

            {

                return Title;

            }

            set

            {

                Title = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Track instead.")]

        public System.Nullable<System.Int32> track

        {

            get

            {

                return Track;

            }

            set

            {

                Track = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TrackCount instead.")]

        public System.Nullable<System.Int32> trackCount

        {

            get

            {

                return TrackCount;

            }

            set

            {

                TrackCount = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Year instead.")]

        public System.Nullable<System.Int32> year

        {

            get

            {

                return Year;

            }

            set

            {

                Year = value;

            }

        }

        public Audio() : base()

        {

        }

    }

    public partial class Deleted : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _state;

        public System.String State

        {

            get

            {

                return _state;

            }

            set

            {

                if (value != _state)

                {

                    _state = value;

                    OnPropertyChanged("state");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use State instead.")]

        public System.String state

        {

            get

            {

                return State;

            }

            set

            {

                State = value;

            }

        }

        public Deleted() : base()

        {

        }

    }

    public partial class File : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.Hashes _hashes;

        private System.String _mimeType;

        public global::Microsoft.Graph.Hashes Hashes

        {

            get

            {

                return _hashes;

            }

            set

            {

                if (value != _hashes)

                {

                    _hashes = value;

                    OnPropertyChanged("hashes");

                }

            }

        }

        public System.String MimeType

        {

            get

            {

                return _mimeType;

            }

            set

            {

                if (value != _mimeType)

                {

                    _mimeType = value;

                    OnPropertyChanged("mimeType");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Hashes instead.")]

        public global::Microsoft.Graph.Hashes hashes

        {

            get

            {

                return Hashes;

            }

            set

            {

                Hashes = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MimeType instead.")]

        public System.String mimeType

        {

            get

            {

                return MimeType;

            }

            set

            {

                MimeType = value;

            }

        }

        public File() : base()

        {

        }

    }

    public partial class Hashes : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _crc32Hash;

        private System.String _sha1Hash;

        public System.String Crc32Hash

        {

            get

            {

                return _crc32Hash;

            }

            set

            {

                if (value != _crc32Hash)

                {

                    _crc32Hash = value;

                    OnPropertyChanged("crc32Hash");

                }

            }

        }

        public System.String Sha1Hash

        {

            get

            {

                return _sha1Hash;

            }

            set

            {

                if (value != _sha1Hash)

                {

                    _sha1Hash = value;

                    OnPropertyChanged("sha1Hash");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Crc32Hash instead.")]

        public System.String crc32Hash

        {

            get

            {

                return Crc32Hash;

            }

            set

            {

                Crc32Hash = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Sha1Hash instead.")]

        public System.String sha1Hash

        {

            get

            {

                return Sha1Hash;

            }

            set

            {

                Sha1Hash = value;

            }

        }

        public Hashes() : base()

        {

        }

    }

    public partial class FileSystemInfo : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.DateTimeOffset> _createdDateTime;

        private System.Nullable<System.DateTimeOffset> _lastModifiedDateTime;

        public System.Nullable<System.DateTimeOffset> CreatedDateTime

        {

            get

            {

                return _createdDateTime;

            }

            set

            {

                if (value != _createdDateTime)

                {

                    _createdDateTime = value;

                    OnPropertyChanged("createdDateTime");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> LastModifiedDateTime

        {

            get

            {

                return _lastModifiedDateTime;

            }

            set

            {

                if (value != _lastModifiedDateTime)

                {

                    _lastModifiedDateTime = value;

                    OnPropertyChanged("lastModifiedDateTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> createdDateTime

        {

            get

            {

                return CreatedDateTime;

            }

            set

            {

                CreatedDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastModifiedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> lastModifiedDateTime

        {

            get

            {

                return LastModifiedDateTime;

            }

            set

            {

                LastModifiedDateTime = value;

            }

        }

        public FileSystemInfo() : base()

        {

        }

    }

    public partial class Folder : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Int32> _childCount;

        public System.Nullable<System.Int32> ChildCount

        {

            get

            {

                return _childCount;

            }

            set

            {

                if (value != _childCount)

                {

                    _childCount = value;

                    OnPropertyChanged("childCount");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChildCount instead.")]

        public System.Nullable<System.Int32> childCount

        {

            get

            {

                return ChildCount;

            }

            set

            {

                ChildCount = value;

            }

        }

        public Folder() : base()

        {

        }

    }

    public partial class Image : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Int32> _height;

        private System.Nullable<System.Int32> _width;

        public System.Nullable<System.Int32> Height

        {

            get

            {

                return _height;

            }

            set

            {

                if (value != _height)

                {

                    _height = value;

                    OnPropertyChanged("height");

                }

            }

        }

        public System.Nullable<System.Int32> Width

        {

            get

            {

                return _width;

            }

            set

            {

                if (value != _width)

                {

                    _width = value;

                    OnPropertyChanged("width");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Height instead.")]

        public System.Nullable<System.Int32> height

        {

            get

            {

                return Height;

            }

            set

            {

                Height = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Width instead.")]

        public System.Nullable<System.Int32> width

        {

            get

            {

                return Width;

            }

            set

            {

                Width = value;

            }

        }

        public Image() : base()

        {

        }

    }

    public partial class GeoCoordinates : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Double> _altitude;

        private System.Nullable<System.Double> _latitude;

        private System.Nullable<System.Double> _longitude;

        public System.Nullable<System.Double> Altitude

        {

            get

            {

                return _altitude;

            }

            set

            {

                if (value != _altitude)

                {

                    _altitude = value;

                    OnPropertyChanged("altitude");

                }

            }

        }

        public System.Nullable<System.Double> Latitude

        {

            get

            {

                return _latitude;

            }

            set

            {

                if (value != _latitude)

                {

                    _latitude = value;

                    OnPropertyChanged("latitude");

                }

            }

        }

        public System.Nullable<System.Double> Longitude

        {

            get

            {

                return _longitude;

            }

            set

            {

                if (value != _longitude)

                {

                    _longitude = value;

                    OnPropertyChanged("longitude");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Altitude instead.")]

        public System.Nullable<System.Double> altitude

        {

            get

            {

                return Altitude;

            }

            set

            {

                Altitude = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Latitude instead.")]

        public System.Nullable<System.Double> latitude

        {

            get

            {

                return Latitude;

            }

            set

            {

                Latitude = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Longitude instead.")]

        public System.Nullable<System.Double> longitude

        {

            get

            {

                return Longitude;

            }

            set

            {

                Longitude = value;

            }

        }

        public GeoCoordinates() : base()

        {

        }

    }

    public partial class OpenWithSet : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.OpenWithApp _web;

        private global::Microsoft.Graph.OpenWithApp _webEmbedded;

        public global::Microsoft.Graph.OpenWithApp Web

        {

            get

            {

                return _web;

            }

            set

            {

                if (value != _web)

                {

                    _web = value;

                    OnPropertyChanged("web");

                }

            }

        }

        public global::Microsoft.Graph.OpenWithApp WebEmbedded

        {

            get

            {

                return _webEmbedded;

            }

            set

            {

                if (value != _webEmbedded)

                {

                    _webEmbedded = value;

                    OnPropertyChanged("webEmbedded");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Web instead.")]

        public global::Microsoft.Graph.OpenWithApp web

        {

            get

            {

                return Web;

            }

            set

            {

                Web = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use WebEmbedded instead.")]

        public global::Microsoft.Graph.OpenWithApp webEmbedded

        {

            get

            {

                return WebEmbedded;

            }

            set

            {

                WebEmbedded = value;

            }

        }

        public OpenWithSet() : base()

        {

        }

    }

    public partial class OpenWithApp : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.Identity _app;

        private System.String _viewUrl;

        private System.String _editUrl;

        private System.String _viewPostParameters;

        private System.String _editPostParameters;

        public global::Microsoft.Graph.Identity App

        {

            get

            {

                return _app;

            }

            set

            {

                if (value != _app)

                {

                    _app = value;

                    OnPropertyChanged("app");

                }

            }

        }

        public System.String ViewUrl

        {

            get

            {

                return _viewUrl;

            }

            set

            {

                if (value != _viewUrl)

                {

                    _viewUrl = value;

                    OnPropertyChanged("viewUrl");

                }

            }

        }

        public System.String EditUrl

        {

            get

            {

                return _editUrl;

            }

            set

            {

                if (value != _editUrl)

                {

                    _editUrl = value;

                    OnPropertyChanged("editUrl");

                }

            }

        }

        public System.String ViewPostParameters

        {

            get

            {

                return _viewPostParameters;

            }

            set

            {

                if (value != _viewPostParameters)

                {

                    _viewPostParameters = value;

                    OnPropertyChanged("viewPostParameters");

                }

            }

        }

        public System.String EditPostParameters

        {

            get

            {

                return _editPostParameters;

            }

            set

            {

                if (value != _editPostParameters)

                {

                    _editPostParameters = value;

                    OnPropertyChanged("editPostParameters");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use App instead.")]

        public global::Microsoft.Graph.Identity app

        {

            get

            {

                return App;

            }

            set

            {

                App = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ViewUrl instead.")]

        public System.String viewUrl

        {

            get

            {

                return ViewUrl;

            }

            set

            {

                ViewUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EditUrl instead.")]

        public System.String editUrl

        {

            get

            {

                return EditUrl;

            }

            set

            {

                EditUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ViewPostParameters instead.")]

        public System.String viewPostParameters

        {

            get

            {

                return ViewPostParameters;

            }

            set

            {

                ViewPostParameters = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EditPostParameters instead.")]

        public System.String editPostParameters

        {

            get

            {

                return EditPostParameters;

            }

            set

            {

                EditPostParameters = value;

            }

        }

        public OpenWithApp() : base()

        {

        }

    }

    public partial class Photo : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _cameraMake;

        private System.String _cameraModel;

        private System.Nullable<System.Double> _exposureDenominator;

        private System.Nullable<System.Double> _exposureNumerator;

        private System.Nullable<System.Double> _focalLength;

        private System.Nullable<System.Double> _fNumber;

        private System.Nullable<System.DateTimeOffset> _takenDateTime;

        private System.Nullable<System.Int32> _iso;

        public System.String CameraMake

        {

            get

            {

                return _cameraMake;

            }

            set

            {

                if (value != _cameraMake)

                {

                    _cameraMake = value;

                    OnPropertyChanged("cameraMake");

                }

            }

        }

        public System.String CameraModel

        {

            get

            {

                return _cameraModel;

            }

            set

            {

                if (value != _cameraModel)

                {

                    _cameraModel = value;

                    OnPropertyChanged("cameraModel");

                }

            }

        }

        public System.Nullable<System.Double> ExposureDenominator

        {

            get

            {

                return _exposureDenominator;

            }

            set

            {

                if (value != _exposureDenominator)

                {

                    _exposureDenominator = value;

                    OnPropertyChanged("exposureDenominator");

                }

            }

        }

        public System.Nullable<System.Double> ExposureNumerator

        {

            get

            {

                return _exposureNumerator;

            }

            set

            {

                if (value != _exposureNumerator)

                {

                    _exposureNumerator = value;

                    OnPropertyChanged("exposureNumerator");

                }

            }

        }

        public System.Nullable<System.Double> FocalLength

        {

            get

            {

                return _focalLength;

            }

            set

            {

                if (value != _focalLength)

                {

                    _focalLength = value;

                    OnPropertyChanged("focalLength");

                }

            }

        }

        public System.Nullable<System.Double> FNumber

        {

            get

            {

                return _fNumber;

            }

            set

            {

                if (value != _fNumber)

                {

                    _fNumber = value;

                    OnPropertyChanged("fNumber");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> TakenDateTime

        {

            get

            {

                return _takenDateTime;

            }

            set

            {

                if (value != _takenDateTime)

                {

                    _takenDateTime = value;

                    OnPropertyChanged("takenDateTime");

                }

            }

        }

        public System.Nullable<System.Int32> Iso

        {

            get

            {

                return _iso;

            }

            set

            {

                if (value != _iso)

                {

                    _iso = value;

                    OnPropertyChanged("iso");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CameraMake instead.")]

        public System.String cameraMake

        {

            get

            {

                return CameraMake;

            }

            set

            {

                CameraMake = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CameraModel instead.")]

        public System.String cameraModel

        {

            get

            {

                return CameraModel;

            }

            set

            {

                CameraModel = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ExposureDenominator instead.")]

        public System.Nullable<System.Double> exposureDenominator

        {

            get

            {

                return ExposureDenominator;

            }

            set

            {

                ExposureDenominator = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ExposureNumerator instead.")]

        public System.Nullable<System.Double> exposureNumerator

        {

            get

            {

                return ExposureNumerator;

            }

            set

            {

                ExposureNumerator = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use FocalLength instead.")]

        public System.Nullable<System.Double> focalLength

        {

            get

            {

                return FocalLength;

            }

            set

            {

                FocalLength = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use FNumber instead.")]

        public System.Nullable<System.Double> fNumber

        {

            get

            {

                return FNumber;

            }

            set

            {

                FNumber = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TakenDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> takenDateTime

        {

            get

            {

                return TakenDateTime;

            }

            set

            {

                TakenDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Iso instead.")]

        public System.Nullable<System.Int32> iso

        {

            get

            {

                return Iso;

            }

            set

            {

                Iso = value;

            }

        }

        public Photo() : base()

        {

        }

    }

    public partial class SearchResult : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _onClickTelemetryUrl;

        public System.String OnClickTelemetryUrl

        {

            get

            {

                return _onClickTelemetryUrl;

            }

            set

            {

                if (value != _onClickTelemetryUrl)

                {

                    _onClickTelemetryUrl = value;

                    OnPropertyChanged("onClickTelemetryUrl");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnClickTelemetryUrl instead.")]

        public System.String onClickTelemetryUrl

        {

            get

            {

                return OnClickTelemetryUrl;

            }

            set

            {

                OnClickTelemetryUrl = value;

            }

        }

        public SearchResult() : base()

        {

        }

    }

    public partial class Shared : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.IdentitySet _owner;

        private System.String _scope;

        public global::Microsoft.Graph.IdentitySet Owner

        {

            get

            {

                return _owner;

            }

            set

            {

                if (value != _owner)

                {

                    _owner = value;

                    OnPropertyChanged("owner");

                }

            }

        }

        public System.String Scope

        {

            get

            {

                return _scope;

            }

            set

            {

                if (value != _scope)

                {

                    _scope = value;

                    OnPropertyChanged("scope");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Owner instead.")]

        public global::Microsoft.Graph.IdentitySet owner

        {

            get

            {

                return Owner;

            }

            set

            {

                Owner = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Scope instead.")]

        public System.String scope

        {

            get

            {

                return Scope;

            }

            set

            {

                Scope = value;

            }

        }

        public Shared() : base()

        {

        }

    }

    public partial class SpecialFolder : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _name;

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        public SpecialFolder() : base()

        {

        }

    }

    public partial class Video : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Int32> _bitrate;

        private System.Nullable<System.Int64> _duration;

        private System.Nullable<System.Int32> _height;

        private System.Nullable<System.Int32> _width;

        public System.Nullable<System.Int32> Bitrate

        {

            get

            {

                return _bitrate;

            }

            set

            {

                if (value != _bitrate)

                {

                    _bitrate = value;

                    OnPropertyChanged("bitrate");

                }

            }

        }

        public System.Nullable<System.Int64> Duration

        {

            get

            {

                return _duration;

            }

            set

            {

                if (value != _duration)

                {

                    _duration = value;

                    OnPropertyChanged("duration");

                }

            }

        }

        public System.Nullable<System.Int32> Height

        {

            get

            {

                return _height;

            }

            set

            {

                if (value != _height)

                {

                    _height = value;

                    OnPropertyChanged("height");

                }

            }

        }

        public System.Nullable<System.Int32> Width

        {

            get

            {

                return _width;

            }

            set

            {

                if (value != _width)

                {

                    _width = value;

                    OnPropertyChanged("width");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Bitrate instead.")]

        public System.Nullable<System.Int32> bitrate

        {

            get

            {

                return Bitrate;

            }

            set

            {

                Bitrate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Duration instead.")]

        public System.Nullable<System.Int64> duration

        {

            get

            {

                return Duration;

            }

            set

            {

                Duration = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Height instead.")]

        public System.Nullable<System.Int32> height

        {

            get

            {

                return Height;

            }

            set

            {

                Height = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Width instead.")]

        public System.Nullable<System.Int32> width

        {

            get

            {

                return Width;

            }

            set

            {

                Width = value;

            }

        }

        public Video() : base()

        {

        }

    }

    public partial class SharingInvitation : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _email;

        private System.String _redeemedBy;

        private System.Nullable<System.Boolean> _signInRequired;

        public System.String Email

        {

            get

            {

                return _email;

            }

            set

            {

                if (value != _email)

                {

                    _email = value;

                    OnPropertyChanged("email");

                }

            }

        }

        public System.String RedeemedBy

        {

            get

            {

                return _redeemedBy;

            }

            set

            {

                if (value != _redeemedBy)

                {

                    _redeemedBy = value;

                    OnPropertyChanged("redeemedBy");

                }

            }

        }

        public System.Nullable<System.Boolean> SignInRequired

        {

            get

            {

                return _signInRequired;

            }

            set

            {

                if (value != _signInRequired)

                {

                    _signInRequired = value;

                    OnPropertyChanged("signInRequired");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Email instead.")]

        public System.String email

        {

            get

            {

                return Email;

            }

            set

            {

                Email = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RedeemedBy instead.")]

        public System.String redeemedBy

        {

            get

            {

                return RedeemedBy;

            }

            set

            {

                RedeemedBy = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SignInRequired instead.")]

        public System.Nullable<System.Boolean> signInRequired

        {

            get

            {

                return SignInRequired;

            }

            set

            {

                SignInRequired = value;

            }

        }

        public SharingInvitation() : base()

        {

        }

    }

    public partial class SharingLink : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.Identity _application;

        private System.String _type;

        private System.String _webUrl;

        public global::Microsoft.Graph.Identity Application

        {

            get

            {

                return _application;

            }

            set

            {

                if (value != _application)

                {

                    _application = value;

                    OnPropertyChanged("application");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.String WebUrl

        {

            get

            {

                return _webUrl;

            }

            set

            {

                if (value != _webUrl)

                {

                    _webUrl = value;

                    OnPropertyChanged("webUrl");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Application instead.")]

        public global::Microsoft.Graph.Identity application

        {

            get

            {

                return Application;

            }

            set

            {

                Application = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use WebUrl instead.")]

        public System.String webUrl

        {

            get

            {

                return WebUrl;

            }

            set

            {

                WebUrl = value;

            }

        }

        public SharingLink() : base()

        {

        }

    }

    public partial class ChunkedUploadSessionDescriptor : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _name;

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        public ChunkedUploadSessionDescriptor() : base()

        {

        }

    }

    public partial class Recipients : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _email;

        private System.String _alias;

        private System.String _objectId;

        private System.String _permissionIdentityType;

        public System.String Email

        {

            get

            {

                return _email;

            }

            set

            {

                if (value != _email)

                {

                    _email = value;

                    OnPropertyChanged("email");

                }

            }

        }

        public System.String Alias

        {

            get

            {

                return _alias;

            }

            set

            {

                if (value != _alias)

                {

                    _alias = value;

                    OnPropertyChanged("alias");

                }

            }

        }

        public System.String ObjectId

        {

            get

            {

                return _objectId;

            }

            set

            {

                if (value != _objectId)

                {

                    _objectId = value;

                    OnPropertyChanged("objectId");

                }

            }

        }

        public System.String PermissionIdentityType

        {

            get

            {

                return _permissionIdentityType;

            }

            set

            {

                if (value != _permissionIdentityType)

                {

                    _permissionIdentityType = value;

                    OnPropertyChanged("permissionIdentityType");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Email instead.")]

        public System.String email

        {

            get

            {

                return Email;

            }

            set

            {

                Email = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Alias instead.")]

        public System.String alias

        {

            get

            {

                return Alias;

            }

            set

            {

                Alias = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ObjectId instead.")]

        public System.String objectId

        {

            get

            {

                return ObjectId;

            }

            set

            {

                ObjectId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PermissionIdentityType instead.")]

        public System.String permissionIdentityType

        {

            get

            {

                return PermissionIdentityType;

            }

            set

            {

                PermissionIdentityType = value;

            }

        }

        public Recipients() : base()

        {

        }

    }

    public partial class UploadSession : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _uploadUrl;

        private System.Nullable<System.DateTimeOffset> _expirationDateTime;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _nextExpectedRanges;

        public System.String UploadUrl

        {

            get

            {

                return _uploadUrl;

            }

            set

            {

                if (value != _uploadUrl)

                {

                    _uploadUrl = value;

                    OnPropertyChanged("uploadUrl");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> ExpirationDateTime

        {

            get

            {

                return _expirationDateTime;

            }

            set

            {

                if (value != _expirationDateTime)

                {

                    _expirationDateTime = value;

                    OnPropertyChanged("expirationDateTime");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> NextExpectedRanges

        {

            get

            {

                if (this._nextExpectedRanges == default(System.Collections.Generic.IList<System.String>))

                {

                    this._nextExpectedRanges = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._nextExpectedRanges.SetContainer(() => GetContainingEntity("nextExpectedRanges"));

                }

                return this._nextExpectedRanges;

            }

            set

            {

                NextExpectedRanges.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        NextExpectedRanges.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UploadUrl instead.")]

        public System.String uploadUrl

        {

            get

            {

                return UploadUrl;

            }

            set

            {

                UploadUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ExpirationDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> expirationDateTime

        {

            get

            {

                return ExpirationDateTime;

            }

            set

            {

                ExpirationDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use NextExpectedRanges instead.")]

        public global::System.Collections.Generic.IList<System.String> nextExpectedRanges

        {

            get

            {

                return NextExpectedRanges;

            }

            set

            {

                NextExpectedRanges = value;

            }

        }

        public UploadSession() : base()

        {

        }

    }

    public partial class Thumbnail : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private Microsoft.OData.Client.DataServiceStreamLink _content;

        private System.Nullable<System.Int32> _height;

        private System.String _url;

        private System.Nullable<System.Int32> _width;

        public Microsoft.OData.Client.DataServiceStreamLink Content

        {

            get

            {

                return _content;

            }

            set

            {

                if (value != _content)

                {

                    _content = value;

                    OnPropertyChanged("content");

                }

            }

        }

        public System.Nullable<System.Int32> Height

        {

            get

            {

                return _height;

            }

            set

            {

                if (value != _height)

                {

                    _height = value;

                    OnPropertyChanged("height");

                }

            }

        }

        public System.String Url

        {

            get

            {

                return _url;

            }

            set

            {

                if (value != _url)

                {

                    _url = value;

                    OnPropertyChanged("url");

                }

            }

        }

        public System.Nullable<System.Int32> Width

        {

            get

            {

                return _width;

            }

            set

            {

                if (value != _width)

                {

                    _width = value;

                    OnPropertyChanged("width");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Content instead.")]

        public Microsoft.OData.Client.DataServiceStreamLink content

        {

            get

            {

                return Content;

            }

            set

            {

                Content = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Height instead.")]

        public System.Nullable<System.Int32> height

        {

            get

            {

                return Height;

            }

            set

            {

                Height = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Url instead.")]

        public System.String url

        {

            get

            {

                return Url;

            }

            set

            {

                Url = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Width instead.")]

        public System.Nullable<System.Int32> width

        {

            get

            {

                return Width;

            }

            set

            {

                Width = value;

            }

        }

        public Thumbnail() : base()

        {

        }

    }

    public partial class NotebookLinks : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.ExternalLink _oneNoteClientUrl;

        private global::Microsoft.Graph.ExternalLink _oneNoteWebUrl;

        /// <summary>
        /// The value of oneNoteClientURL can be used to open the notebook using the OneNote native client app if it's installed.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink OneNoteClientUrl

        {

            get

            {

                return _oneNoteClientUrl;

            }

            set

            {

                if (value != _oneNoteClientUrl)

                {

                    _oneNoteClientUrl = value;

                    OnPropertyChanged("oneNoteClientUrl");

                }

            }

        }

        /// <summary>
        /// The value of oneNoteWebURL can be used to open the web-browser based OneNote Online client.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink OneNoteWebUrl

        {

            get

            {

                return _oneNoteWebUrl;

            }

            set

            {

                if (value != _oneNoteWebUrl)

                {

                    _oneNoteWebUrl = value;

                    OnPropertyChanged("oneNoteWebUrl");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OneNoteClientUrl instead.")]

        /// <summary>
        /// The value of oneNoteClientURL can be used to open the notebook using the OneNote native client app if it's installed.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink oneNoteClientUrl

        {

            get

            {

                return OneNoteClientUrl;

            }

            set

            {

                OneNoteClientUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OneNoteWebUrl instead.")]

        /// <summary>
        /// The value of oneNoteWebURL can be used to open the web-browser based OneNote Online client.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink oneNoteWebUrl

        {

            get

            {

                return OneNoteWebUrl;

            }

            set

            {

                OneNoteWebUrl = value;

            }

        }

        public NotebookLinks() : base()

        {

        }

    }

    public partial class ExternalLink : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _href;

        public System.String Href

        {

            get

            {

                return _href;

            }

            set

            {

                if (value != _href)

                {

                    _href = value;

                    OnPropertyChanged("href");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Href instead.")]

        public System.String href

        {

            get

            {

                return Href;

            }

            set

            {

                Href = value;

            }

        }

        public ExternalLink() : base()

        {

        }

    }

    public partial class OneNoteIdentitySet : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.OneNoteIdentity _user;

        public global::Microsoft.Graph.OneNoteIdentity User

        {

            get

            {

                return _user;

            }

            set

            {

                if (value != _user)

                {

                    _user = value;

                    OnPropertyChanged("user");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use User instead.")]

        public global::Microsoft.Graph.OneNoteIdentity user

        {

            get

            {

                return User;

            }

            set

            {

                User = value;

            }

        }

        public OneNoteIdentitySet() : base()

        {

        }

    }

    public partial class OneNoteIdentity : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _id;

        private System.String _displayName;

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        public OneNoteIdentity() : base()

        {

        }

    }

    public partial class PageLinks : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.ExternalLink _oneNoteClientUrl;

        private global::Microsoft.Graph.ExternalLink _oneNoteWebUrl;

        /// <summary>
        /// The value of oneNoteClientURL can be used to open the notebook using the OneNote native client app if it's installed.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink OneNoteClientUrl

        {

            get

            {

                return _oneNoteClientUrl;

            }

            set

            {

                if (value != _oneNoteClientUrl)

                {

                    _oneNoteClientUrl = value;

                    OnPropertyChanged("oneNoteClientUrl");

                }

            }

        }

        /// <summary>
        /// The value of oneNoteWebURL can be used to open the web-browser based OneNote Online client.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink OneNoteWebUrl

        {

            get

            {

                return _oneNoteWebUrl;

            }

            set

            {

                if (value != _oneNoteWebUrl)

                {

                    _oneNoteWebUrl = value;

                    OnPropertyChanged("oneNoteWebUrl");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OneNoteClientUrl instead.")]

        /// <summary>
        /// The value of oneNoteClientURL can be used to open the notebook using the OneNote native client app if it's installed.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink oneNoteClientUrl

        {

            get

            {

                return OneNoteClientUrl;

            }

            set

            {

                OneNoteClientUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OneNoteWebUrl instead.")]

        /// <summary>
        /// The value of oneNoteWebURL can be used to open the web-browser based OneNote Online client.
        /// </summary>
        public global::Microsoft.Graph.ExternalLink oneNoteWebUrl

        {

            get

            {

                return OneNoteWebUrl;

            }

            set

            {

                OneNoteWebUrl = value;

            }

        }

        public PageLinks() : base()

        {

        }

    }

    public partial class NotesOperationError : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _code;

        private System.String _message;

        public System.String Code

        {

            get

            {

                return _code;

            }

            set

            {

                if (value != _code)

                {

                    _code = value;

                    OnPropertyChanged("code");

                }

            }

        }

        public System.String Message

        {

            get

            {

                return _message;

            }

            set

            {

                if (value != _message)

                {

                    _message = value;

                    OnPropertyChanged("message");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Code instead.")]

        public System.String code

        {

            get

            {

                return Code;

            }

            set

            {

                Code = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Message instead.")]

        public System.String message

        {

            get

            {

                return Message;

            }

            set

            {

                Message = value;

            }

        }

        public NotesOperationError() : base()

        {

        }

    }

    public partial class Diagnostic : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _message;

        private System.String _url;

        public System.String Message

        {

            get

            {

                return _message;

            }

            set

            {

                if (value != _message)

                {

                    _message = value;

                    OnPropertyChanged("message");

                }

            }

        }

        public System.String Url

        {

            get

            {

                return _url;

            }

            set

            {

                if (value != _url)

                {

                    _url = value;

                    OnPropertyChanged("url");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Message instead.")]

        public System.String message

        {

            get

            {

                return Message;

            }

            set

            {

                Message = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Url instead.")]

        public System.String url

        {

            get

            {

                return Url;

            }

            set

            {

                Url = value;

            }

        }

        public Diagnostic() : base()

        {

        }

    }

    public partial class PatchContentCommand : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private global::Microsoft.Graph.PatchActionType _action;

        private System.String _target;

        private System.String _content;

        private global::Microsoft.Graph.PatchInsertPosition _position;

        public global::Microsoft.Graph.PatchActionType Action

        {

            get

            {

                return _action;

            }

            set

            {

                if (value != _action)

                {

                    _action = value;

                    OnPropertyChanged("action");

                }

            }

        }

        public System.String Target

        {

            get

            {

                return _target;

            }

            set

            {

                if (value != _target)

                {

                    _target = value;

                    OnPropertyChanged("target");

                }

            }

        }

        public System.String Content

        {

            get

            {

                return _content;

            }

            set

            {

                if (value != _content)

                {

                    _content = value;

                    OnPropertyChanged("content");

                }

            }

        }

        public global::Microsoft.Graph.PatchInsertPosition Position

        {

            get

            {

                return _position;

            }

            set

            {

                if (value != _position)

                {

                    _position = value;

                    OnPropertyChanged("position");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Action instead.")]

        public global::Microsoft.Graph.PatchActionType action

        {

            get

            {

                return Action;

            }

            set

            {

                Action = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Target instead.")]

        public System.String target

        {

            get

            {

                return Target;

            }

            set

            {

                Target = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Content instead.")]

        public System.String content

        {

            get

            {

                return Content;

            }

            set

            {

                Content = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Position instead.")]

        public global::Microsoft.Graph.PatchInsertPosition position

        {

            get

            {

                return Position;

            }

            set

            {

                Position = value;

            }

        }

        public PatchContentCommand() : base()

        {

        }

    }

    public partial class CopyStatusModel : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _id;

        private System.String _status;

        private System.Nullable<System.DateTimeOffset> _createdDateTime;

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String Status

        {

            get

            {

                return _status;

            }

            set

            {

                if (value != _status)

                {

                    _status = value;

                    OnPropertyChanged("status");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> CreatedDateTime

        {

            get

            {

                return _createdDateTime;

            }

            set

            {

                if (value != _createdDateTime)

                {

                    _createdDateTime = value;

                    OnPropertyChanged("createdDateTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Status instead.")]

        public System.String status

        {

            get

            {

                return Status;

            }

            set

            {

                Status = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> createdDateTime

        {

            get

            {

                return CreatedDateTime;

            }

            set

            {

                CreatedDateTime = value;

            }

        }

        public CopyStatusModel() : base()

        {

        }

    }

    public partial class ImportStatusModel : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _id;

        private System.String _status;

        private System.Nullable<System.DateTimeOffset> _createdDateTime;

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String Status

        {

            get

            {

                return _status;

            }

            set

            {

                if (value != _status)

                {

                    _status = value;

                    OnPropertyChanged("status");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> CreatedDateTime

        {

            get

            {

                return _createdDateTime;

            }

            set

            {

                if (value != _createdDateTime)

                {

                    _createdDateTime = value;

                    OnPropertyChanged("createdDateTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Status instead.")]

        public System.String status

        {

            get

            {

                return Status;

            }

            set

            {

                Status = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> createdDateTime

        {

            get

            {

                return CreatedDateTime;

            }

            set

            {

                CreatedDateTime = value;

            }

        }

        public ImportStatusModel() : base()

        {

        }

    }

    public partial class AppliedCategoriesCollection : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        public AppliedCategoriesCollection() : base()

        {

        }

    }

    public partial class ExternalReference : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.String _alias;

        private System.String _type;

        private System.String _previewPriority;

        private System.String _lastModifiedBy;

        private System.Nullable<System.DateTimeOffset> _lastModifiedDateTime;

        public System.String Alias

        {

            get

            {

                return _alias;

            }

            set

            {

                if (value != _alias)

                {

                    _alias = value;

                    OnPropertyChanged("alias");

                }

            }

        }

        public System.String Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.String PreviewPriority

        {

            get

            {

                return _previewPriority;

            }

            set

            {

                if (value != _previewPriority)

                {

                    _previewPriority = value;

                    OnPropertyChanged("previewPriority");

                }

            }

        }

        public System.String LastModifiedBy

        {

            get

            {

                return _lastModifiedBy;

            }

            set

            {

                if (value != _lastModifiedBy)

                {

                    _lastModifiedBy = value;

                    OnPropertyChanged("lastModifiedBy");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> LastModifiedDateTime

        {

            get

            {

                return _lastModifiedDateTime;

            }

            set

            {

                if (value != _lastModifiedDateTime)

                {

                    _lastModifiedDateTime = value;

                    OnPropertyChanged("lastModifiedDateTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Alias instead.")]

        public System.String alias

        {

            get

            {

                return Alias;

            }

            set

            {

                Alias = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public System.String type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PreviewPriority instead.")]

        public System.String previewPriority

        {

            get

            {

                return PreviewPriority;

            }

            set

            {

                PreviewPriority = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastModifiedBy instead.")]

        public System.String lastModifiedBy

        {

            get

            {

                return LastModifiedBy;

            }

            set

            {

                LastModifiedBy = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastModifiedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> lastModifiedDateTime

        {

            get

            {

                return LastModifiedDateTime;

            }

            set

            {

                LastModifiedDateTime = value;

            }

        }

        public ExternalReference() : base()

        {

        }

    }

    public partial class ChecklistItem : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        private System.Nullable<System.Boolean> _isChecked;

        private System.String _title;

        private System.String _orderHint;

        private System.String _lastModifiedBy;

        private System.Nullable<System.DateTimeOffset> _lastModifiedDateTime;

        public System.Nullable<System.Boolean> IsChecked

        {

            get

            {

                return _isChecked;

            }

            set

            {

                if (value != _isChecked)

                {

                    _isChecked = value;

                    OnPropertyChanged("isChecked");

                }

            }

        }

        public System.String Title

        {

            get

            {

                return _title;

            }

            set

            {

                if (value != _title)

                {

                    _title = value;

                    OnPropertyChanged("title");

                }

            }

        }

        public System.String OrderHint

        {

            get

            {

                return _orderHint;

            }

            set

            {

                if (value != _orderHint)

                {

                    _orderHint = value;

                    OnPropertyChanged("orderHint");

                }

            }

        }

        public System.String LastModifiedBy

        {

            get

            {

                return _lastModifiedBy;

            }

            set

            {

                if (value != _lastModifiedBy)

                {

                    _lastModifiedBy = value;

                    OnPropertyChanged("lastModifiedBy");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> LastModifiedDateTime

        {

            get

            {

                return _lastModifiedDateTime;

            }

            set

            {

                if (value != _lastModifiedDateTime)

                {

                    _lastModifiedDateTime = value;

                    OnPropertyChanged("lastModifiedDateTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsChecked instead.")]

        public System.Nullable<System.Boolean> isChecked

        {

            get

            {

                return IsChecked;

            }

            set

            {

                IsChecked = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Title instead.")]

        public System.String title

        {

            get

            {

                return Title;

            }

            set

            {

                Title = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OrderHint instead.")]

        public System.String orderHint

        {

            get

            {

                return OrderHint;

            }

            set

            {

                OrderHint = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastModifiedBy instead.")]

        public System.String lastModifiedBy

        {

            get

            {

                return LastModifiedBy;

            }

            set

            {

                LastModifiedBy = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastModifiedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> lastModifiedDateTime

        {

            get

            {

                return LastModifiedDateTime;

            }

            set

            {

                LastModifiedDateTime = value;

            }

        }

        public ChecklistItem() : base()

        {

        }

    }

    public partial class ExternalReferenceCollection : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        public ExternalReferenceCollection() : base()

        {

        }

    }

    public partial class ChecklistItemCollection : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        public ChecklistItemCollection() : base()

        {

        }

    }

    public partial class UserIdCollection : Microsoft.OData.ProxyExtensions.ComplexTypeBase

    {

        public UserIdCollection() : base()

        {

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class DirectoryObject : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.IDirectoryObjectFetcher

    {

        private System.String _id;

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        public DirectoryObject() : base()

        {

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.String>> checkMemberGroupsAsync(System.Collections.Generic.ICollection<System.String> groupIds)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/checkMemberGroups");

            return (await this.Context.ExecuteAsync<System.String>(requestUri, "POST", false, new OperationParameter[]

            {

                new BodyOperationParameter("groupIds", (object) groupIds),

            }

            ));

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.String>> getMemberGroupsAsync(System.Nullable<System.Boolean> securityEnabledOnly)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/getMemberGroups");

            return (await this.Context.ExecuteAsync<System.String>(requestUri, "POST", false, new OperationParameter[]

            {

                new BodyOperationParameter("securityEnabledOnly", (object) securityEnabledOnly),

            }

            ));

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.String>> getMemberObjectsAsync(System.Nullable<System.Boolean> securityEnabledOnly)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/getMemberObjects");

            return (await this.Context.ExecuteAsync<System.String>(requestUri, "POST", false, new OperationParameter[]

            {

                new BodyOperationParameter("securityEnabledOnly", (object) securityEnabledOnly),

            }

            ));

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryObject> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IDirectoryObject>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryObject> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IDirectoryObjectFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IDirectoryObject>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IDirectoryObjectFetcher global::Microsoft.Graph.IDirectoryObjectFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDirectoryObject, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDirectoryObjectFetcher)this;

        }

    }

    internal partial class DirectoryObjectFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IDirectoryObjectFetcher

    {

        public DirectoryObjectFetcher() : base()

        {

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.String>> checkMemberGroupsAsync(System.Collections.Generic.ICollection<System.String> groupIds)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/checkMemberGroups");

            return (await this.Context.ExecuteAsync<System.String>(requestUri, "POST", false, new OperationParameter[]

            {

                new BodyOperationParameter("groupIds", (object) groupIds),

            }

            ));

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.String>> getMemberGroupsAsync(System.Nullable<System.Boolean> securityEnabledOnly)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/getMemberGroups");

            return (await this.Context.ExecuteAsync<System.String>(requestUri, "POST", false, new OperationParameter[]

            {

                new BodyOperationParameter("securityEnabledOnly", (object) securityEnabledOnly),

            }

            ));

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<System.String>> getMemberObjectsAsync(System.Nullable<System.Boolean> securityEnabledOnly)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/getMemberObjects");

            return (await this.Context.ExecuteAsync<System.String>(requestUri, "POST", false, new OperationParameter[]

            {

                new BodyOperationParameter("securityEnabledOnly", (object) securityEnabledOnly),

            }

            ));

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDirectoryObject> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IDirectoryObjectFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDirectoryObject, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDirectoryObjectFetcher)new global::Microsoft.Graph.DirectoryObjectFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryObject> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IDirectoryObject>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryObject> _query;

    }

    internal partial class DirectoryObjectCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IDirectoryObject>, global::Microsoft.Graph.IDirectoryObjectCollection

    {

        internal DirectoryObjectCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IDirectoryObjectFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AdddirectoryObjectAsync(global::Microsoft.Graph.IDirectoryObject item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.DirectoryObject>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class DirectoryObjectCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class ExtensionProperty : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IExtensionProperty, global::Microsoft.Graph.IExtensionPropertyFetcher

    {

        private System.String _appDisplayName;

        private System.String _name;

        private System.String _dataType;

        private System.Nullable<System.Boolean> _isSyncedFromOnPremises;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _targetObjects;

        public System.String AppDisplayName

        {

            get

            {

                return _appDisplayName;

            }

            set

            {

                if (value != _appDisplayName)

                {

                    _appDisplayName = value;

                    OnPropertyChanged("appDisplayName");

                }

            }

        }

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        public System.String DataType

        {

            get

            {

                return _dataType;

            }

            set

            {

                if (value != _dataType)

                {

                    _dataType = value;

                    OnPropertyChanged("dataType");

                }

            }

        }

        public System.Nullable<System.Boolean> IsSyncedFromOnPremises

        {

            get

            {

                return _isSyncedFromOnPremises;

            }

            set

            {

                if (value != _isSyncedFromOnPremises)

                {

                    _isSyncedFromOnPremises = value;

                    OnPropertyChanged("isSyncedFromOnPremises");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> TargetObjects

        {

            get

            {

                if (this._targetObjects == default(System.Collections.Generic.IList<System.String>))

                {

                    this._targetObjects = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._targetObjects.SetContainer(() => GetContainingEntity("targetObjects"));

                }

                return this._targetObjects;

            }

            set

            {

                TargetObjects.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        TargetObjects.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppDisplayName instead.")]

        public System.String appDisplayName

        {

            get

            {

                return AppDisplayName;

            }

            set

            {

                AppDisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DataType instead.")]

        public System.String dataType

        {

            get

            {

                return DataType;

            }

            set

            {

                DataType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsSyncedFromOnPremises instead.")]

        public System.Nullable<System.Boolean> isSyncedFromOnPremises

        {

            get

            {

                return IsSyncedFromOnPremises;

            }

            set

            {

                IsSyncedFromOnPremises = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TargetObjects instead.")]

        public global::System.Collections.Generic.IList<System.String> targetObjects

        {

            get

            {

                return TargetObjects;

            }

            set

            {

                TargetObjects = value;

            }

        }

        public ExtensionProperty()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IExtensionProperty> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ExtensionProperty, global::Microsoft.Graph.IExtensionProperty>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IExtensionProperty> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IExtensionProperty> global::Microsoft.Graph.IExtensionPropertyFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IExtensionProperty>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IExtensionPropertyFetcher global::Microsoft.Graph.IExtensionPropertyFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IExtensionProperty, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IExtensionPropertyFetcher)this;

        }

    }

    internal partial class ExtensionPropertyFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IExtensionPropertyFetcher

    {

        public ExtensionPropertyFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IExtensionProperty> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IExtensionPropertyFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IExtensionProperty, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IExtensionPropertyFetcher)new global::Microsoft.Graph.ExtensionPropertyFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IExtensionProperty> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ExtensionProperty, global::Microsoft.Graph.IExtensionProperty>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IExtensionProperty> _query;

    }

    internal partial class ExtensionPropertyCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IExtensionProperty>, global::Microsoft.Graph.IExtensionPropertyCollection

    {

        internal ExtensionPropertyCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IExtensionPropertyFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IExtensionProperty>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddextensionPropertyAsync(global::Microsoft.Graph.IExtensionProperty item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IExtensionPropertyFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.ExtensionProperty>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.ExtensionPropertyFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class ExtensionPropertyCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Application : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IApplication, global::Microsoft.Graph.IApplicationFetcher

    {

        private global::Microsoft.Graph.DirectoryObject _createdOnBehalfOf;

        private global::Microsoft.Graph.DirectoryObjectFetcher _createdOnBehalfOfFetcher;

        private global::Microsoft.Graph.ExtensionPropertyCollection _extensionPropertiesCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownersCollection;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AddIn> _addIns;

        private System.String _appId;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AppRole> _appRoles;

        private System.Nullable<System.Boolean> _availableToOtherOrganizations;

        private System.String _displayName;

        private System.String _errorUrl;

        private System.String _groupMembershipClaims;

        private System.String _homepage;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _identifierUris;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.KeyCredential> _keyCredentials;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.Guid> _knownClientApplications;

        private Microsoft.OData.Client.DataServiceStreamLink _mainLogo;

        private System.String _logoutUrl;

        private System.Boolean _oauth2AllowImplicitFlow;

        private System.Boolean _oauth2AllowUrlPathMatching;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.OAuth2Permission> _oauth2Permissions;

        private System.Boolean _oauth2RequirePostResponse;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.PasswordCredential> _passwordCredentials;

        private System.Nullable<System.Boolean> _publicClient;

        private System.String _recordConsentConditions;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _replyUrls;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.RequiredResourceAccess> _requiredResourceAccess;

        private System.String _samlMetadataUrl;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ExtensionProperty> _extensionPropertiesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _ownersConcrete;

        public System.Collections.Generic.IList<global::Microsoft.Graph.AddIn> AddIns

        {

            get

            {

                if (this._addIns == default(System.Collections.Generic.IList<global::Microsoft.Graph.AddIn>))

                {

                    this._addIns = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AddIn>();

                    this._addIns.SetContainer(() => GetContainingEntity("addIns"));

                }

                return this._addIns;

            }

            set

            {

                AddIns.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AddIns.Add(i);

                    }

                }

            }

        }

        public System.String AppId

        {

            get

            {

                return _appId;

            }

            set

            {

                if (value != _appId)

                {

                    _appId = value;

                    OnPropertyChanged("appId");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AppRole> AppRoles

        {

            get

            {

                if (this._appRoles == default(System.Collections.Generic.IList<global::Microsoft.Graph.AppRole>))

                {

                    this._appRoles = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AppRole>();

                    this._appRoles.SetContainer(() => GetContainingEntity("appRoles"));

                }

                return this._appRoles;

            }

            set

            {

                AppRoles.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AppRoles.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.Boolean> AvailableToOtherOrganizations

        {

            get

            {

                return _availableToOtherOrganizations;

            }

            set

            {

                if (value != _availableToOtherOrganizations)

                {

                    _availableToOtherOrganizations = value;

                    OnPropertyChanged("availableToOtherOrganizations");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String ErrorUrl

        {

            get

            {

                return _errorUrl;

            }

            set

            {

                if (value != _errorUrl)

                {

                    _errorUrl = value;

                    OnPropertyChanged("errorUrl");

                }

            }

        }

        public System.String GroupMembershipClaims

        {

            get

            {

                return _groupMembershipClaims;

            }

            set

            {

                if (value != _groupMembershipClaims)

                {

                    _groupMembershipClaims = value;

                    OnPropertyChanged("groupMembershipClaims");

                }

            }

        }

        public System.String Homepage

        {

            get

            {

                return _homepage;

            }

            set

            {

                if (value != _homepage)

                {

                    _homepage = value;

                    OnPropertyChanged("homepage");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> IdentifierUris

        {

            get

            {

                if (this._identifierUris == default(System.Collections.Generic.IList<System.String>))

                {

                    this._identifierUris = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._identifierUris.SetContainer(() => GetContainingEntity("identifierUris"));

                }

                return this._identifierUris;

            }

            set

            {

                IdentifierUris.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        IdentifierUris.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.KeyCredential> KeyCredentials

        {

            get

            {

                if (this._keyCredentials == default(System.Collections.Generic.IList<global::Microsoft.Graph.KeyCredential>))

                {

                    this._keyCredentials = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.KeyCredential>();

                    this._keyCredentials.SetContainer(() => GetContainingEntity("keyCredentials"));

                }

                return this._keyCredentials;

            }

            set

            {

                KeyCredentials.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        KeyCredentials.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.Guid> KnownClientApplications

        {

            get

            {

                if (this._knownClientApplications == default(System.Collections.Generic.IList<System.Guid>))

                {

                    this._knownClientApplications = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.Guid>();

                    this._knownClientApplications.SetContainer(() => GetContainingEntity("knownClientApplications"));

                }

                return this._knownClientApplications;

            }

            set

            {

                KnownClientApplications.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        KnownClientApplications.Add(i);

                    }

                }

            }

        }

        public Microsoft.OData.Client.DataServiceStreamLink MainLogo

        {

            get

            {

                return _mainLogo;

            }

            set

            {

                if (value != _mainLogo)

                {

                    _mainLogo = value;

                    OnPropertyChanged("mainLogo");

                }

            }

        }

        public System.String LogoutUrl

        {

            get

            {

                return _logoutUrl;

            }

            set

            {

                if (value != _logoutUrl)

                {

                    _logoutUrl = value;

                    OnPropertyChanged("logoutUrl");

                }

            }

        }

        public System.Boolean Oauth2AllowImplicitFlow

        {

            get

            {

                return _oauth2AllowImplicitFlow;

            }

            set

            {

                if (value != _oauth2AllowImplicitFlow)

                {

                    _oauth2AllowImplicitFlow = value;

                    OnPropertyChanged("oauth2AllowImplicitFlow");

                }

            }

        }

        public System.Boolean Oauth2AllowUrlPathMatching

        {

            get

            {

                return _oauth2AllowUrlPathMatching;

            }

            set

            {

                if (value != _oauth2AllowUrlPathMatching)

                {

                    _oauth2AllowUrlPathMatching = value;

                    OnPropertyChanged("oauth2AllowUrlPathMatching");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2Permission> Oauth2Permissions

        {

            get

            {

                if (this._oauth2Permissions == default(System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2Permission>))

                {

                    this._oauth2Permissions = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.OAuth2Permission>();

                    this._oauth2Permissions.SetContainer(() => GetContainingEntity("oauth2Permissions"));

                }

                return this._oauth2Permissions;

            }

            set

            {

                Oauth2Permissions.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Oauth2Permissions.Add(i);

                    }

                }

            }

        }

        public System.Boolean Oauth2RequirePostResponse

        {

            get

            {

                return _oauth2RequirePostResponse;

            }

            set

            {

                if (value != _oauth2RequirePostResponse)

                {

                    _oauth2RequirePostResponse = value;

                    OnPropertyChanged("oauth2RequirePostResponse");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.PasswordCredential> PasswordCredentials

        {

            get

            {

                if (this._passwordCredentials == default(System.Collections.Generic.IList<global::Microsoft.Graph.PasswordCredential>))

                {

                    this._passwordCredentials = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.PasswordCredential>();

                    this._passwordCredentials.SetContainer(() => GetContainingEntity("passwordCredentials"));

                }

                return this._passwordCredentials;

            }

            set

            {

                PasswordCredentials.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        PasswordCredentials.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.Boolean> PublicClient

        {

            get

            {

                return _publicClient;

            }

            set

            {

                if (value != _publicClient)

                {

                    _publicClient = value;

                    OnPropertyChanged("publicClient");

                }

            }

        }

        public System.String RecordConsentConditions

        {

            get

            {

                return _recordConsentConditions;

            }

            set

            {

                if (value != _recordConsentConditions)

                {

                    _recordConsentConditions = value;

                    OnPropertyChanged("recordConsentConditions");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ReplyUrls

        {

            get

            {

                if (this._replyUrls == default(System.Collections.Generic.IList<System.String>))

                {

                    this._replyUrls = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._replyUrls.SetContainer(() => GetContainingEntity("replyUrls"));

                }

                return this._replyUrls;

            }

            set

            {

                ReplyUrls.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ReplyUrls.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.RequiredResourceAccess> RequiredResourceAccess

        {

            get

            {

                if (this._requiredResourceAccess == default(System.Collections.Generic.IList<global::Microsoft.Graph.RequiredResourceAccess>))

                {

                    this._requiredResourceAccess = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.RequiredResourceAccess>();

                    this._requiredResourceAccess.SetContainer(() => GetContainingEntity("requiredResourceAccess"));

                }

                return this._requiredResourceAccess;

            }

            set

            {

                RequiredResourceAccess.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        RequiredResourceAccess.Add(i);

                    }

                }

            }

        }

        public System.String SamlMetadataUrl

        {

            get

            {

                return _samlMetadataUrl;

            }

            set

            {

                if (value != _samlMetadataUrl)

                {

                    _samlMetadataUrl = value;

                    OnPropertyChanged("samlMetadataUrl");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IExtensionProperty> global::Microsoft.Graph.IApplication.ExtensionProperties

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IExtensionProperty, global::Microsoft.Graph.ExtensionProperty>(Context, (DataServiceCollection<global::Microsoft.Graph.ExtensionProperty>)ExtensionProperties);

            }

        }

        global::Microsoft.Graph.IDirectoryObject global::Microsoft.Graph.IApplication.CreatedOnBehalfOf

        {

            get

            {

                return this._createdOnBehalfOf;

            }

            set

            {

                if (this.CreatedOnBehalfOf != value)

                {

                    this.CreatedOnBehalfOf = (global::Microsoft.Graph.DirectoryObject)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IApplication.Owners

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)Owners);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AddIns instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AddIn> addIns

        {

            get

            {

                return AddIns;

            }

            set

            {

                AddIns = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppId instead.")]

        public System.String appId

        {

            get

            {

                return AppId;

            }

            set

            {

                AppId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppRoles instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRole> appRoles

        {

            get

            {

                return AppRoles;

            }

            set

            {

                AppRoles = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AvailableToOtherOrganizations instead.")]

        public System.Nullable<System.Boolean> availableToOtherOrganizations

        {

            get

            {

                return AvailableToOtherOrganizations;

            }

            set

            {

                AvailableToOtherOrganizations = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ErrorUrl instead.")]

        public System.String errorUrl

        {

            get

            {

                return ErrorUrl;

            }

            set

            {

                ErrorUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use GroupMembershipClaims instead.")]

        public System.String groupMembershipClaims

        {

            get

            {

                return GroupMembershipClaims;

            }

            set

            {

                GroupMembershipClaims = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Homepage instead.")]

        public System.String homepage

        {

            get

            {

                return Homepage;

            }

            set

            {

                Homepage = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IdentifierUris instead.")]

        public global::System.Collections.Generic.IList<System.String> identifierUris

        {

            get

            {

                return IdentifierUris;

            }

            set

            {

                IdentifierUris = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use KeyCredentials instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.KeyCredential> keyCredentials

        {

            get

            {

                return KeyCredentials;

            }

            set

            {

                KeyCredentials = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use KnownClientApplications instead.")]

        public global::System.Collections.Generic.IList<System.Guid> knownClientApplications

        {

            get

            {

                return KnownClientApplications;

            }

            set

            {

                KnownClientApplications = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MainLogo instead.")]

        public Microsoft.OData.Client.DataServiceStreamLink mainLogo

        {

            get

            {

                return MainLogo;

            }

            set

            {

                MainLogo = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LogoutUrl instead.")]

        public System.String logoutUrl

        {

            get

            {

                return LogoutUrl;

            }

            set

            {

                LogoutUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Oauth2AllowImplicitFlow instead.")]

        public System.Boolean oauth2AllowImplicitFlow

        {

            get

            {

                return Oauth2AllowImplicitFlow;

            }

            set

            {

                Oauth2AllowImplicitFlow = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Oauth2AllowUrlPathMatching instead.")]

        public System.Boolean oauth2AllowUrlPathMatching

        {

            get

            {

                return Oauth2AllowUrlPathMatching;

            }

            set

            {

                Oauth2AllowUrlPathMatching = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Oauth2Permissions instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2Permission> oauth2Permissions

        {

            get

            {

                return Oauth2Permissions;

            }

            set

            {

                Oauth2Permissions = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Oauth2RequirePostResponse instead.")]

        public System.Boolean oauth2RequirePostResponse

        {

            get

            {

                return Oauth2RequirePostResponse;

            }

            set

            {

                Oauth2RequirePostResponse = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PasswordCredentials instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.PasswordCredential> passwordCredentials

        {

            get

            {

                return PasswordCredentials;

            }

            set

            {

                PasswordCredentials = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PublicClient instead.")]

        public System.Nullable<System.Boolean> publicClient

        {

            get

            {

                return PublicClient;

            }

            set

            {

                PublicClient = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RecordConsentConditions instead.")]

        public System.String recordConsentConditions

        {

            get

            {

                return RecordConsentConditions;

            }

            set

            {

                RecordConsentConditions = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ReplyUrls instead.")]

        public global::System.Collections.Generic.IList<System.String> replyUrls

        {

            get

            {

                return ReplyUrls;

            }

            set

            {

                ReplyUrls = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RequiredResourceAccess instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.RequiredResourceAccess> requiredResourceAccess

        {

            get

            {

                return RequiredResourceAccess;

            }

            set

            {

                RequiredResourceAccess = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SamlMetadataUrl instead.")]

        public System.String samlMetadataUrl

        {

            get

            {

                return SamlMetadataUrl;

            }

            set

            {

                SamlMetadataUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ExtensionProperties instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ExtensionProperty> extensionProperties

        {

            get

            {

                return ExtensionProperties;

            }

            set

            {

                ExtensionProperties = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedOnBehalfOf instead.")]

        public global::Microsoft.Graph.DirectoryObject createdOnBehalfOf

        {

            get

            {

                return CreatedOnBehalfOf;

            }

            set

            {

                CreatedOnBehalfOf = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Owners instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> owners

        {

            get

            {

                return Owners;

            }

            set

            {

                Owners = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ExtensionProperty> ExtensionProperties

        {

            get

            {

                if (this._extensionPropertiesConcrete == null)

                {

                    this._extensionPropertiesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ExtensionProperty>();

                    this._extensionPropertiesConcrete.SetContainer(() => GetContainingEntity("extensionProperties"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.ExtensionProperty>)this._extensionPropertiesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                ExtensionProperties.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ExtensionProperties.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.DirectoryObject CreatedOnBehalfOf

        {

            get

            {

                return this._createdOnBehalfOf;

            }

            set

            {

                if (this._createdOnBehalfOf != value)

                {

                    this._createdOnBehalfOf = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "createdOnBehalfOf", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> Owners

        {

            get

            {

                if (this._ownersConcrete == null)

                {

                    this._ownersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._ownersConcrete.SetContainer(() => GetContainingEntity("owners"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._ownersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Owners.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Owners.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IExtensionPropertyCollection global::Microsoft.Graph.IApplicationFetcher.ExtensionProperties

        {

            get

            {

                if (this._extensionPropertiesCollection == null)

                {

                    this._extensionPropertiesCollection = new global::Microsoft.Graph.ExtensionPropertyCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ExtensionProperty>(GetPath("extensionProperties")) : null,
                       Context,
                       this,
                       GetPath("extensionProperties"));

                }



                return this._extensionPropertiesCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectFetcher global::Microsoft.Graph.IApplicationFetcher.CreatedOnBehalfOf

        {

            get

            {

                if (this._createdOnBehalfOfFetcher == null)

                {

                    this._createdOnBehalfOfFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._createdOnBehalfOfFetcher.Initialize(this.Context, GetPath("createdOnBehalfOf"));

                }



                return this._createdOnBehalfOfFetcher;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IApplicationFetcher.Owners

        {

            get

            {

                if (this._ownersCollection == null)

                {

                    this._ownersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("owners")) : null,
                       Context,
                       this,
                       GetPath("owners"));

                }



                return this._ownersCollection;

            }

        }

        public Application()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IApplication> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Application, global::Microsoft.Graph.IApplication>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IApplication> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IApplication> global::Microsoft.Graph.IApplicationFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IApplication>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IApplicationFetcher global::Microsoft.Graph.IApplicationFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IApplication, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IApplicationFetcher)this;

        }

    }

    internal partial class ApplicationFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IApplicationFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectFetcher _createdOnBehalfOfFetcher;

        private global::Microsoft.Graph.ExtensionPropertyCollection _extensionPropertiesCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownersCollection;

        public global::Microsoft.Graph.IExtensionPropertyCollection ExtensionProperties

        {

            get

            {

                if (this._extensionPropertiesCollection == null)

                {

                    this._extensionPropertiesCollection = new global::Microsoft.Graph.ExtensionPropertyCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ExtensionProperty>(GetPath("extensionProperties")) : null,
                       Context,
                       this,
                       GetPath("extensionProperties"));

                }



                return this._extensionPropertiesCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectFetcher CreatedOnBehalfOf

        {

            get

            {

                if (this._createdOnBehalfOfFetcher == null)

                {

                    this._createdOnBehalfOfFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._createdOnBehalfOfFetcher.Initialize(this.Context, GetPath("createdOnBehalfOf"));

                }



                return this._createdOnBehalfOfFetcher;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection Owners

        {

            get

            {

                if (this._ownersCollection == null)

                {

                    this._ownersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("owners")) : null,
                       Context,
                       this,
                       GetPath("owners"));

                }



                return this._ownersCollection;

            }

        }

        public ApplicationFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IApplication> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IApplicationFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IApplication, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IApplicationFetcher)new global::Microsoft.Graph.ApplicationFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IApplication> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Application, global::Microsoft.Graph.IApplication>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IApplication> _query;

    }

    internal partial class ApplicationCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IApplication>, global::Microsoft.Graph.IApplicationCollection

    {

        internal ApplicationCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IApplicationFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IApplication>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddapplicationAsync(global::Microsoft.Graph.IApplication item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IApplicationFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Application>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.ApplicationFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class ApplicationCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class AppRoleAssignment : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IAppRoleAssignment, global::Microsoft.Graph.IAppRoleAssignmentFetcher

    {

        private System.Nullable<System.DateTimeOffset> _creationTimestamp;

        private System.Guid _id;

        private System.String _principalDisplayName;

        private System.Nullable<System.Guid> _principalId;

        private System.String _principalType;

        private System.String _resourceDisplayName;

        private System.Nullable<System.Guid> _resourceId;

        public System.Nullable<System.DateTimeOffset> CreationTimestamp

        {

            get

            {

                return _creationTimestamp;

            }

            set

            {

                if (value != _creationTimestamp)

                {

                    _creationTimestamp = value;

                    OnPropertyChanged("creationTimestamp");

                }

            }

        }

        public System.Guid Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String PrincipalDisplayName

        {

            get

            {

                return _principalDisplayName;

            }

            set

            {

                if (value != _principalDisplayName)

                {

                    _principalDisplayName = value;

                    OnPropertyChanged("principalDisplayName");

                }

            }

        }

        public System.Nullable<System.Guid> PrincipalId

        {

            get

            {

                return _principalId;

            }

            set

            {

                if (value != _principalId)

                {

                    _principalId = value;

                    OnPropertyChanged("principalId");

                }

            }

        }

        public System.String PrincipalType

        {

            get

            {

                return _principalType;

            }

            set

            {

                if (value != _principalType)

                {

                    _principalType = value;

                    OnPropertyChanged("principalType");

                }

            }

        }

        public System.String ResourceDisplayName

        {

            get

            {

                return _resourceDisplayName;

            }

            set

            {

                if (value != _resourceDisplayName)

                {

                    _resourceDisplayName = value;

                    OnPropertyChanged("resourceDisplayName");

                }

            }

        }

        public System.Nullable<System.Guid> ResourceId

        {

            get

            {

                return _resourceId;

            }

            set

            {

                if (value != _resourceId)

                {

                    _resourceId = value;

                    OnPropertyChanged("resourceId");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreationTimestamp instead.")]

        public System.Nullable<System.DateTimeOffset> creationTimestamp

        {

            get

            {

                return CreationTimestamp;

            }

            set

            {

                CreationTimestamp = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.Guid id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PrincipalDisplayName instead.")]

        public System.String principalDisplayName

        {

            get

            {

                return PrincipalDisplayName;

            }

            set

            {

                PrincipalDisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PrincipalId instead.")]

        public System.Nullable<System.Guid> principalId

        {

            get

            {

                return PrincipalId;

            }

            set

            {

                PrincipalId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PrincipalType instead.")]

        public System.String principalType

        {

            get

            {

                return PrincipalType;

            }

            set

            {

                PrincipalType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResourceDisplayName instead.")]

        public System.String resourceDisplayName

        {

            get

            {

                return ResourceDisplayName;

            }

            set

            {

                ResourceDisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResourceId instead.")]

        public System.Nullable<System.Guid> resourceId

        {

            get

            {

                return ResourceId;

            }

            set

            {

                ResourceId = value;

            }

        }

        public AppRoleAssignment() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IAppRoleAssignment> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.AppRoleAssignment, global::Microsoft.Graph.IAppRoleAssignment>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IAppRoleAssignment> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IAppRoleAssignment> global::Microsoft.Graph.IAppRoleAssignmentFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IAppRoleAssignment>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IAppRoleAssignmentFetcher global::Microsoft.Graph.IAppRoleAssignmentFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IAppRoleAssignment, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IAppRoleAssignmentFetcher)this;

        }

    }

    internal partial class AppRoleAssignmentFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IAppRoleAssignmentFetcher

    {

        public AppRoleAssignmentFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IAppRoleAssignment> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IAppRoleAssignmentFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IAppRoleAssignment, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IAppRoleAssignmentFetcher)new global::Microsoft.Graph.AppRoleAssignmentFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IAppRoleAssignment> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.AppRoleAssignment, global::Microsoft.Graph.IAppRoleAssignment>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IAppRoleAssignment> _query;

    }

    internal partial class AppRoleAssignmentCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IAppRoleAssignment>, global::Microsoft.Graph.IAppRoleAssignmentCollection

    {

        internal AppRoleAssignmentCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IAppRoleAssignmentFetcher GetById(System.Guid id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IAppRoleAssignment>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddappRoleAssignmentAsync(global::Microsoft.Graph.IAppRoleAssignment item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IAppRoleAssignmentFetcher this[System.Guid id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.AppRoleAssignment>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.AppRoleAssignmentFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class AppRoleAssignmentCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class OrgContact : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IOrgContact, global::Microsoft.Graph.IOrgContactFetcher

    {

        private global::Microsoft.Graph.DirectoryObject _manager;

        private global::Microsoft.Graph.DirectoryObjectFetcher _managerFetcher;

        private global::Microsoft.Graph.DirectoryObjectCollection _directReportsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _businessPhones;

        private System.String _city;

        private System.String _companyName;

        private System.String _country;

        private System.String _department;

        private System.String _displayName;

        private System.String _givenName;

        private System.String _jobTitle;

        private System.String _mail;

        private System.String _mailNickname;

        private System.String _mobilePhone;

        private System.Nullable<System.Boolean> _onPremisesSyncEnabled;

        private System.Nullable<System.DateTimeOffset> _onPremisesLastSyncDateTime;

        private System.String _officeLocation;

        private System.String _postalCode;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _proxyAddresses;

        private System.String _state;

        private System.String _streetAddress;

        private System.String _surname;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _directReportsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _memberOfConcrete;

        public System.Collections.Generic.IList<System.String> BusinessPhones

        {

            get

            {

                if (this._businessPhones == default(System.Collections.Generic.IList<System.String>))

                {

                    this._businessPhones = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._businessPhones.SetContainer(() => GetContainingEntity("businessPhones"));

                }

                return this._businessPhones;

            }

            set

            {

                BusinessPhones.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        BusinessPhones.Add(i);

                    }

                }

            }

        }

        public System.String City

        {

            get

            {

                return _city;

            }

            set

            {

                if (value != _city)

                {

                    _city = value;

                    OnPropertyChanged("city");

                }

            }

        }

        public System.String CompanyName

        {

            get

            {

                return _companyName;

            }

            set

            {

                if (value != _companyName)

                {

                    _companyName = value;

                    OnPropertyChanged("companyName");

                }

            }

        }

        public System.String Country

        {

            get

            {

                return _country;

            }

            set

            {

                if (value != _country)

                {

                    _country = value;

                    OnPropertyChanged("country");

                }

            }

        }

        public System.String Department

        {

            get

            {

                return _department;

            }

            set

            {

                if (value != _department)

                {

                    _department = value;

                    OnPropertyChanged("department");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String GivenName

        {

            get

            {

                return _givenName;

            }

            set

            {

                if (value != _givenName)

                {

                    _givenName = value;

                    OnPropertyChanged("givenName");

                }

            }

        }

        public System.String JobTitle

        {

            get

            {

                return _jobTitle;

            }

            set

            {

                if (value != _jobTitle)

                {

                    _jobTitle = value;

                    OnPropertyChanged("jobTitle");

                }

            }

        }

        public System.String Mail

        {

            get

            {

                return _mail;

            }

            set

            {

                if (value != _mail)

                {

                    _mail = value;

                    OnPropertyChanged("mail");

                }

            }

        }

        public System.String MailNickname

        {

            get

            {

                return _mailNickname;

            }

            set

            {

                if (value != _mailNickname)

                {

                    _mailNickname = value;

                    OnPropertyChanged("mailNickname");

                }

            }

        }

        public System.String MobilePhone

        {

            get

            {

                return _mobilePhone;

            }

            set

            {

                if (value != _mobilePhone)

                {

                    _mobilePhone = value;

                    OnPropertyChanged("mobilePhone");

                }

            }

        }

        public System.Nullable<System.Boolean> OnPremisesSyncEnabled

        {

            get

            {

                return _onPremisesSyncEnabled;

            }

            set

            {

                if (value != _onPremisesSyncEnabled)

                {

                    _onPremisesSyncEnabled = value;

                    OnPropertyChanged("onPremisesSyncEnabled");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> OnPremisesLastSyncDateTime

        {

            get

            {

                return _onPremisesLastSyncDateTime;

            }

            set

            {

                if (value != _onPremisesLastSyncDateTime)

                {

                    _onPremisesLastSyncDateTime = value;

                    OnPropertyChanged("onPremisesLastSyncDateTime");

                }

            }

        }

        public System.String OfficeLocation

        {

            get

            {

                return _officeLocation;

            }

            set

            {

                if (value != _officeLocation)

                {

                    _officeLocation = value;

                    OnPropertyChanged("officeLocation");

                }

            }

        }

        public System.String PostalCode

        {

            get

            {

                return _postalCode;

            }

            set

            {

                if (value != _postalCode)

                {

                    _postalCode = value;

                    OnPropertyChanged("postalCode");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ProxyAddresses

        {

            get

            {

                if (this._proxyAddresses == default(System.Collections.Generic.IList<System.String>))

                {

                    this._proxyAddresses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._proxyAddresses.SetContainer(() => GetContainingEntity("proxyAddresses"));

                }

                return this._proxyAddresses;

            }

            set

            {

                ProxyAddresses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ProxyAddresses.Add(i);

                    }

                }

            }

        }

        public System.String State

        {

            get

            {

                return _state;

            }

            set

            {

                if (value != _state)

                {

                    _state = value;

                    OnPropertyChanged("state");

                }

            }

        }

        public System.String StreetAddress

        {

            get

            {

                return _streetAddress;

            }

            set

            {

                if (value != _streetAddress)

                {

                    _streetAddress = value;

                    OnPropertyChanged("streetAddress");

                }

            }

        }

        public System.String Surname

        {

            get

            {

                return _surname;

            }

            set

            {

                if (value != _surname)

                {

                    _surname = value;

                    OnPropertyChanged("surname");

                }

            }

        }

        global::Microsoft.Graph.IDirectoryObject global::Microsoft.Graph.IOrgContact.Manager

        {

            get

            {

                return this._manager;

            }

            set

            {

                if (this.Manager != value)

                {

                    this.Manager = (global::Microsoft.Graph.DirectoryObject)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IOrgContact.DirectReports

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)DirectReports);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IOrgContact.MemberOf

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)MemberOf);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BusinessPhones instead.")]

        public global::System.Collections.Generic.IList<System.String> businessPhones

        {

            get

            {

                return BusinessPhones;

            }

            set

            {

                BusinessPhones = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use City instead.")]

        public System.String city

        {

            get

            {

                return City;

            }

            set

            {

                City = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CompanyName instead.")]

        public System.String companyName

        {

            get

            {

                return CompanyName;

            }

            set

            {

                CompanyName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Country instead.")]

        public System.String country

        {

            get

            {

                return Country;

            }

            set

            {

                Country = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Department instead.")]

        public System.String department

        {

            get

            {

                return Department;

            }

            set

            {

                Department = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use GivenName instead.")]

        public System.String givenName

        {

            get

            {

                return GivenName;

            }

            set

            {

                GivenName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use JobTitle instead.")]

        public System.String jobTitle

        {

            get

            {

                return JobTitle;

            }

            set

            {

                JobTitle = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Mail instead.")]

        public System.String mail

        {

            get

            {

                return Mail;

            }

            set

            {

                Mail = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MailNickname instead.")]

        public System.String mailNickname

        {

            get

            {

                return MailNickname;

            }

            set

            {

                MailNickname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MobilePhone instead.")]

        public System.String mobilePhone

        {

            get

            {

                return MobilePhone;

            }

            set

            {

                MobilePhone = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSyncEnabled instead.")]

        public System.Nullable<System.Boolean> onPremisesSyncEnabled

        {

            get

            {

                return OnPremisesSyncEnabled;

            }

            set

            {

                OnPremisesSyncEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesLastSyncDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> onPremisesLastSyncDateTime

        {

            get

            {

                return OnPremisesLastSyncDateTime;

            }

            set

            {

                OnPremisesLastSyncDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OfficeLocation instead.")]

        public System.String officeLocation

        {

            get

            {

                return OfficeLocation;

            }

            set

            {

                OfficeLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PostalCode instead.")]

        public System.String postalCode

        {

            get

            {

                return PostalCode;

            }

            set

            {

                PostalCode = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProxyAddresses instead.")]

        public global::System.Collections.Generic.IList<System.String> proxyAddresses

        {

            get

            {

                return ProxyAddresses;

            }

            set

            {

                ProxyAddresses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use State instead.")]

        public System.String state

        {

            get

            {

                return State;

            }

            set

            {

                State = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use StreetAddress instead.")]

        public System.String streetAddress

        {

            get

            {

                return StreetAddress;

            }

            set

            {

                StreetAddress = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Surname instead.")]

        public System.String surname

        {

            get

            {

                return Surname;

            }

            set

            {

                Surname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Manager instead.")]

        public global::Microsoft.Graph.DirectoryObject manager

        {

            get

            {

                return Manager;

            }

            set

            {

                Manager = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DirectReports instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> directReports

        {

            get

            {

                return DirectReports;

            }

            set

            {

                DirectReports = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MemberOf instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> memberOf

        {

            get

            {

                return MemberOf;

            }

            set

            {

                MemberOf = value;

            }

        }

        public global::Microsoft.Graph.DirectoryObject Manager

        {

            get

            {

                return this._manager;

            }

            set

            {

                if (this._manager != value)

                {

                    this._manager = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "manager", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> DirectReports

        {

            get

            {

                if (this._directReportsConcrete == null)

                {

                    this._directReportsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._directReportsConcrete.SetContainer(() => GetContainingEntity("directReports"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._directReportsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                DirectReports.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        DirectReports.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> MemberOf

        {

            get

            {

                if (this._memberOfConcrete == null)

                {

                    this._memberOfConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._memberOfConcrete.SetContainer(() => GetContainingEntity("memberOf"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._memberOfConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                MemberOf.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        MemberOf.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IDirectoryObjectFetcher global::Microsoft.Graph.IOrgContactFetcher.Manager

        {

            get

            {

                if (this._managerFetcher == null)

                {

                    this._managerFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._managerFetcher.Initialize(this.Context, GetPath("manager"));

                }



                return this._managerFetcher;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IOrgContactFetcher.DirectReports

        {

            get

            {

                if (this._directReportsCollection == null)

                {

                    this._directReportsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("directReports")) : null,
                       Context,
                       this,
                       GetPath("directReports"));

                }



                return this._directReportsCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IOrgContactFetcher.MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        public OrgContact()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrgContact> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.OrgContact, global::Microsoft.Graph.IOrgContact>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrgContact> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IOrgContact> global::Microsoft.Graph.IOrgContactFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IOrgContact>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IOrgContactFetcher global::Microsoft.Graph.IOrgContactFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IOrgContact, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IOrgContactFetcher)this;

        }

    }

    internal partial class OrgContactFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IOrgContactFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectFetcher _managerFetcher;

        private global::Microsoft.Graph.DirectoryObjectCollection _directReportsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        public global::Microsoft.Graph.IDirectoryObjectFetcher Manager

        {

            get

            {

                if (this._managerFetcher == null)

                {

                    this._managerFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._managerFetcher.Initialize(this.Context, GetPath("manager"));

                }



                return this._managerFetcher;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection DirectReports

        {

            get

            {

                if (this._directReportsCollection == null)

                {

                    this._directReportsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("directReports")) : null,
                       Context,
                       this,
                       GetPath("directReports"));

                }



                return this._directReportsCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        public OrgContactFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IOrgContact> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IOrgContactFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IOrgContact, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IOrgContactFetcher)new global::Microsoft.Graph.OrgContactFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrgContact> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.OrgContact, global::Microsoft.Graph.IOrgContact>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrgContact> _query;

    }

    internal partial class OrgContactCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IOrgContact>, global::Microsoft.Graph.IOrgContactCollection

    {

        internal OrgContactCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IOrgContactFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IOrgContact>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddorgContactAsync(global::Microsoft.Graph.IOrgContact item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IOrgContactFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.OrgContact>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.OrgContactFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class OrgContactCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Device : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IDevice, global::Microsoft.Graph.IDeviceFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectCollection _registeredOwnersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _registeredUsersCollection;

        private System.Nullable<System.Boolean> _accountEnabled;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AlternativeSecurityId> _alternativeSecurityIds;

        private System.Nullable<System.DateTimeOffset> _approximateLastSignInDateTime;

        private System.String _deviceId;

        private System.String _deviceMetadata;

        private System.Nullable<System.Int32> _deviceVersion;

        private System.String _displayName;

        private System.Nullable<System.Boolean> _isCompliant;

        private System.Nullable<System.Boolean> _isManaged;

        private System.Nullable<System.DateTimeOffset> _onPremisesLastSyncDateTime;

        private System.Nullable<System.Boolean> _onPremisesSyncEnabled;

        private System.String _operatingSystem;

        private System.String _operatingSystemVersion;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _physicalIds;

        private System.String _trustType;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _registeredOwnersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _registeredUsersConcrete;

        public System.Nullable<System.Boolean> AccountEnabled

        {

            get

            {

                return _accountEnabled;

            }

            set

            {

                if (value != _accountEnabled)

                {

                    _accountEnabled = value;

                    OnPropertyChanged("accountEnabled");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AlternativeSecurityId> AlternativeSecurityIds

        {

            get

            {

                if (this._alternativeSecurityIds == default(System.Collections.Generic.IList<global::Microsoft.Graph.AlternativeSecurityId>))

                {

                    this._alternativeSecurityIds = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AlternativeSecurityId>();

                    this._alternativeSecurityIds.SetContainer(() => GetContainingEntity("alternativeSecurityIds"));

                }

                return this._alternativeSecurityIds;

            }

            set

            {

                AlternativeSecurityIds.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AlternativeSecurityIds.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> ApproximateLastSignInDateTime

        {

            get

            {

                return _approximateLastSignInDateTime;

            }

            set

            {

                if (value != _approximateLastSignInDateTime)

                {

                    _approximateLastSignInDateTime = value;

                    OnPropertyChanged("approximateLastSignInDateTime");

                }

            }

        }

        public System.String DeviceId

        {

            get

            {

                return _deviceId;

            }

            set

            {

                if (value != _deviceId)

                {

                    _deviceId = value;

                    OnPropertyChanged("deviceId");

                }

            }

        }

        public System.String DeviceMetadata

        {

            get

            {

                return _deviceMetadata;

            }

            set

            {

                if (value != _deviceMetadata)

                {

                    _deviceMetadata = value;

                    OnPropertyChanged("deviceMetadata");

                }

            }

        }

        public System.Nullable<System.Int32> DeviceVersion

        {

            get

            {

                return _deviceVersion;

            }

            set

            {

                if (value != _deviceVersion)

                {

                    _deviceVersion = value;

                    OnPropertyChanged("deviceVersion");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.Nullable<System.Boolean> IsCompliant

        {

            get

            {

                return _isCompliant;

            }

            set

            {

                if (value != _isCompliant)

                {

                    _isCompliant = value;

                    OnPropertyChanged("isCompliant");

                }

            }

        }

        public System.Nullable<System.Boolean> IsManaged

        {

            get

            {

                return _isManaged;

            }

            set

            {

                if (value != _isManaged)

                {

                    _isManaged = value;

                    OnPropertyChanged("isManaged");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> OnPremisesLastSyncDateTime

        {

            get

            {

                return _onPremisesLastSyncDateTime;

            }

            set

            {

                if (value != _onPremisesLastSyncDateTime)

                {

                    _onPremisesLastSyncDateTime = value;

                    OnPropertyChanged("onPremisesLastSyncDateTime");

                }

            }

        }

        public System.Nullable<System.Boolean> OnPremisesSyncEnabled

        {

            get

            {

                return _onPremisesSyncEnabled;

            }

            set

            {

                if (value != _onPremisesSyncEnabled)

                {

                    _onPremisesSyncEnabled = value;

                    OnPropertyChanged("onPremisesSyncEnabled");

                }

            }

        }

        public System.String OperatingSystem

        {

            get

            {

                return _operatingSystem;

            }

            set

            {

                if (value != _operatingSystem)

                {

                    _operatingSystem = value;

                    OnPropertyChanged("operatingSystem");

                }

            }

        }

        public System.String OperatingSystemVersion

        {

            get

            {

                return _operatingSystemVersion;

            }

            set

            {

                if (value != _operatingSystemVersion)

                {

                    _operatingSystemVersion = value;

                    OnPropertyChanged("operatingSystemVersion");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> PhysicalIds

        {

            get

            {

                if (this._physicalIds == default(System.Collections.Generic.IList<System.String>))

                {

                    this._physicalIds = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._physicalIds.SetContainer(() => GetContainingEntity("physicalIds"));

                }

                return this._physicalIds;

            }

            set

            {

                PhysicalIds.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        PhysicalIds.Add(i);

                    }

                }

            }

        }

        public System.String TrustType

        {

            get

            {

                return _trustType;

            }

            set

            {

                if (value != _trustType)

                {

                    _trustType = value;

                    OnPropertyChanged("trustType");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IDevice.RegisteredOwners

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)RegisteredOwners);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IDevice.RegisteredUsers

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)RegisteredUsers);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AccountEnabled instead.")]

        public System.Nullable<System.Boolean> accountEnabled

        {

            get

            {

                return AccountEnabled;

            }

            set

            {

                AccountEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AlternativeSecurityIds instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AlternativeSecurityId> alternativeSecurityIds

        {

            get

            {

                return AlternativeSecurityIds;

            }

            set

            {

                AlternativeSecurityIds = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ApproximateLastSignInDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> approximateLastSignInDateTime

        {

            get

            {

                return ApproximateLastSignInDateTime;

            }

            set

            {

                ApproximateLastSignInDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DeviceId instead.")]

        public System.String deviceId

        {

            get

            {

                return DeviceId;

            }

            set

            {

                DeviceId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DeviceMetadata instead.")]

        public System.String deviceMetadata

        {

            get

            {

                return DeviceMetadata;

            }

            set

            {

                DeviceMetadata = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DeviceVersion instead.")]

        public System.Nullable<System.Int32> deviceVersion

        {

            get

            {

                return DeviceVersion;

            }

            set

            {

                DeviceVersion = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsCompliant instead.")]

        public System.Nullable<System.Boolean> isCompliant

        {

            get

            {

                return IsCompliant;

            }

            set

            {

                IsCompliant = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsManaged instead.")]

        public System.Nullable<System.Boolean> isManaged

        {

            get

            {

                return IsManaged;

            }

            set

            {

                IsManaged = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesLastSyncDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> onPremisesLastSyncDateTime

        {

            get

            {

                return OnPremisesLastSyncDateTime;

            }

            set

            {

                OnPremisesLastSyncDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSyncEnabled instead.")]

        public System.Nullable<System.Boolean> onPremisesSyncEnabled

        {

            get

            {

                return OnPremisesSyncEnabled;

            }

            set

            {

                OnPremisesSyncEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OperatingSystem instead.")]

        public System.String operatingSystem

        {

            get

            {

                return OperatingSystem;

            }

            set

            {

                OperatingSystem = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OperatingSystemVersion instead.")]

        public System.String operatingSystemVersion

        {

            get

            {

                return OperatingSystemVersion;

            }

            set

            {

                OperatingSystemVersion = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PhysicalIds instead.")]

        public global::System.Collections.Generic.IList<System.String> physicalIds

        {

            get

            {

                return PhysicalIds;

            }

            set

            {

                PhysicalIds = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TrustType instead.")]

        public System.String trustType

        {

            get

            {

                return TrustType;

            }

            set

            {

                TrustType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RegisteredOwners instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> registeredOwners

        {

            get

            {

                return RegisteredOwners;

            }

            set

            {

                RegisteredOwners = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RegisteredUsers instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> registeredUsers

        {

            get

            {

                return RegisteredUsers;

            }

            set

            {

                RegisteredUsers = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> RegisteredOwners

        {

            get

            {

                if (this._registeredOwnersConcrete == null)

                {

                    this._registeredOwnersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._registeredOwnersConcrete.SetContainer(() => GetContainingEntity("registeredOwners"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._registeredOwnersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                RegisteredOwners.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        RegisteredOwners.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> RegisteredUsers

        {

            get

            {

                if (this._registeredUsersConcrete == null)

                {

                    this._registeredUsersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._registeredUsersConcrete.SetContainer(() => GetContainingEntity("registeredUsers"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._registeredUsersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                RegisteredUsers.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        RegisteredUsers.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IDeviceFetcher.RegisteredOwners

        {

            get

            {

                if (this._registeredOwnersCollection == null)

                {

                    this._registeredOwnersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("registeredOwners")) : null,
                       Context,
                       this,
                       GetPath("registeredOwners"));

                }



                return this._registeredOwnersCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IDeviceFetcher.RegisteredUsers

        {

            get

            {

                if (this._registeredUsersCollection == null)

                {

                    this._registeredUsersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("registeredUsers")) : null,
                       Context,
                       this,
                       GetPath("registeredUsers"));

                }



                return this._registeredUsersCollection;

            }

        }

        public Device()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDevice> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Device, global::Microsoft.Graph.IDevice>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDevice> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDevice> global::Microsoft.Graph.IDeviceFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IDevice>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IDeviceFetcher global::Microsoft.Graph.IDeviceFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDevice, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDeviceFetcher)this;

        }

    }

    internal partial class DeviceFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IDeviceFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectCollection _registeredOwnersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _registeredUsersCollection;

        public global::Microsoft.Graph.IDirectoryObjectCollection RegisteredOwners

        {

            get

            {

                if (this._registeredOwnersCollection == null)

                {

                    this._registeredOwnersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("registeredOwners")) : null,
                       Context,
                       this,
                       GetPath("registeredOwners"));

                }



                return this._registeredOwnersCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection RegisteredUsers

        {

            get

            {

                if (this._registeredUsersCollection == null)

                {

                    this._registeredUsersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("registeredUsers")) : null,
                       Context,
                       this,
                       GetPath("registeredUsers"));

                }



                return this._registeredUsersCollection;

            }

        }

        public DeviceFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDevice> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IDeviceFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDevice, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDeviceFetcher)new global::Microsoft.Graph.DeviceFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDevice> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Device, global::Microsoft.Graph.IDevice>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDevice> _query;

    }

    internal partial class DeviceCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IDevice>, global::Microsoft.Graph.IDeviceCollection

    {

        internal DeviceCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IDeviceFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDevice>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AdddeviceAsync(global::Microsoft.Graph.IDevice item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IDeviceFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Device>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.DeviceFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class DeviceCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class DirectoryRole : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IDirectoryRole, global::Microsoft.Graph.IDirectoryRoleFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectCollection _membersCollection;

        private System.String _description;

        private System.String _displayName;

        private System.String _roleTemplateId;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _membersConcrete;

        public System.String Description

        {

            get

            {

                return _description;

            }

            set

            {

                if (value != _description)

                {

                    _description = value;

                    OnPropertyChanged("description");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String RoleTemplateId

        {

            get

            {

                return _roleTemplateId;

            }

            set

            {

                if (value != _roleTemplateId)

                {

                    _roleTemplateId = value;

                    OnPropertyChanged("roleTemplateId");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IDirectoryRole.Members

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)Members);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Description instead.")]

        public System.String description

        {

            get

            {

                return Description;

            }

            set

            {

                Description = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RoleTemplateId instead.")]

        public System.String roleTemplateId

        {

            get

            {

                return RoleTemplateId;

            }

            set

            {

                RoleTemplateId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Members instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> members

        {

            get

            {

                return Members;

            }

            set

            {

                Members = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> Members

        {

            get

            {

                if (this._membersConcrete == null)

                {

                    this._membersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._membersConcrete.SetContainer(() => GetContainingEntity("members"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._membersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Members.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Members.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IDirectoryRoleFetcher.Members

        {

            get

            {

                if (this._membersCollection == null)

                {

                    this._membersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("members")) : null,
                       Context,
                       this,
                       GetPath("members"));

                }



                return this._membersCollection;

            }

        }

        public DirectoryRole()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRole> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.DirectoryRole, global::Microsoft.Graph.IDirectoryRole>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRole> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDirectoryRole> global::Microsoft.Graph.IDirectoryRoleFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IDirectoryRole>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IDirectoryRoleFetcher global::Microsoft.Graph.IDirectoryRoleFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDirectoryRole, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDirectoryRoleFetcher)this;

        }

    }

    internal partial class DirectoryRoleFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IDirectoryRoleFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectCollection _membersCollection;

        public global::Microsoft.Graph.IDirectoryObjectCollection Members

        {

            get

            {

                if (this._membersCollection == null)

                {

                    this._membersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("members")) : null,
                       Context,
                       this,
                       GetPath("members"));

                }



                return this._membersCollection;

            }

        }

        public DirectoryRoleFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDirectoryRole> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IDirectoryRoleFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDirectoryRole, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDirectoryRoleFetcher)new global::Microsoft.Graph.DirectoryRoleFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRole> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.DirectoryRole, global::Microsoft.Graph.IDirectoryRole>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRole> _query;

    }

    internal partial class DirectoryRoleCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IDirectoryRole>, global::Microsoft.Graph.IDirectoryRoleCollection

    {

        internal DirectoryRoleCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IDirectoryRoleFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryRole>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AdddirectoryRoleAsync(global::Microsoft.Graph.IDirectoryRole item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IDirectoryRoleFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.DirectoryRole>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.DirectoryRoleFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class DirectoryRoleCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class DirectoryRoleTemplate : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IDirectoryRoleTemplate, global::Microsoft.Graph.IDirectoryRoleTemplateFetcher

    {

        private System.String _description;

        private System.String _displayName;

        public System.String Description

        {

            get

            {

                return _description;

            }

            set

            {

                if (value != _description)

                {

                    _description = value;

                    OnPropertyChanged("description");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Description instead.")]

        public System.String description

        {

            get

            {

                return Description;

            }

            set

            {

                Description = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        public DirectoryRoleTemplate()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRoleTemplate> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.DirectoryRoleTemplate, global::Microsoft.Graph.IDirectoryRoleTemplate>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRoleTemplate> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDirectoryRoleTemplate> global::Microsoft.Graph.IDirectoryRoleTemplateFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IDirectoryRoleTemplate>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IDirectoryRoleTemplateFetcher global::Microsoft.Graph.IDirectoryRoleTemplateFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDirectoryRoleTemplate, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDirectoryRoleTemplateFetcher)this;

        }

    }

    internal partial class DirectoryRoleTemplateFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IDirectoryRoleTemplateFetcher

    {

        public DirectoryRoleTemplateFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDirectoryRoleTemplate> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IDirectoryRoleTemplateFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDirectoryRoleTemplate, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDirectoryRoleTemplateFetcher)new global::Microsoft.Graph.DirectoryRoleTemplateFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRoleTemplate> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.DirectoryRoleTemplate, global::Microsoft.Graph.IDirectoryRoleTemplate>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDirectoryRoleTemplate> _query;

    }

    internal partial class DirectoryRoleTemplateCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IDirectoryRoleTemplate>, global::Microsoft.Graph.IDirectoryRoleTemplateCollection

    {

        internal DirectoryRoleTemplateCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IDirectoryRoleTemplateFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryRoleTemplate>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AdddirectoryRoleTemplateAsync(global::Microsoft.Graph.IDirectoryRoleTemplate item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IDirectoryRoleTemplateFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.DirectoryRoleTemplate>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.DirectoryRoleTemplateFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class DirectoryRoleTemplateCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Group : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IGroup, global::Microsoft.Graph.IGroupFetcher

    {

        private global::Microsoft.Graph.DirectoryObject _createdOnBehalfOf;

        private global::Microsoft.Graph.Calendar _calendar;

        private global::Microsoft.Graph.ProfilePhoto _photo;

        private global::Microsoft.Graph.Drive _drive;

        private global::Microsoft.Graph.Notes _notes;

        private global::Microsoft.Graph.DirectoryObjectFetcher _createdOnBehalfOfFetcher;

        private global::Microsoft.Graph.CalendarFetcher _calendarFetcher;

        private global::Microsoft.Graph.ProfilePhotoFetcher _photoFetcher;

        private global::Microsoft.Graph.DriveFetcher _driveFetcher;

        private global::Microsoft.Graph.NotesFetcher _notesFetcher;

        private global::Microsoft.Graph.DirectoryObjectCollection _membersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownersCollection;

        private global::Microsoft.Graph.ConversationThreadCollection _threadsCollection;

        private global::Microsoft.Graph.EventCollection _calendarViewCollection;

        private global::Microsoft.Graph.EventCollection _eventsCollection;

        private global::Microsoft.Graph.ConversationCollection _conversationsCollection;

        private global::Microsoft.Graph.ProfilePhotoCollection _photosCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _acceptedSendersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _rejectedSendersCollection;

        private global::Microsoft.Graph.PlanCollection _plansCollection;

        private System.String _description;

        private System.String _displayName;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _groupTypes;

        private System.String _mail;

        private System.Nullable<System.Boolean> _mailEnabled;

        private System.String _mailNickname;

        private System.Nullable<System.DateTimeOffset> _onPremisesLastSyncDateTime;

        private System.String _onPremisesSecurityIdentifier;

        private System.Nullable<System.Boolean> _onPremisesSyncEnabled;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _proxyAddresses;

        private System.Nullable<System.Boolean> _securityEnabled;

        private System.String _visibility;

        private global::Microsoft.Graph.GroupAccessType _accessType;

        private System.Nullable<System.Boolean> _allowExternalSenders;

        private System.Nullable<System.Boolean> _autoSubscribeNewMembers;

        private System.Nullable<System.Boolean> _isFavorite;

        private System.Nullable<System.Boolean> _isSubscribedByMail;

        private System.Nullable<System.Int32> _unseenCount;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _membersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _memberOfConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _ownersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ConversationThread> _threadsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _calendarViewConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _eventsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Conversation> _conversationsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ProfilePhoto> _photosConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _acceptedSendersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _rejectedSendersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Plan> _plansConcrete;

        public System.String Description

        {

            get

            {

                return _description;

            }

            set

            {

                if (value != _description)

                {

                    _description = value;

                    OnPropertyChanged("description");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> GroupTypes

        {

            get

            {

                if (this._groupTypes == default(System.Collections.Generic.IList<System.String>))

                {

                    this._groupTypes = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._groupTypes.SetContainer(() => GetContainingEntity("groupTypes"));

                }

                return this._groupTypes;

            }

            set

            {

                GroupTypes.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        GroupTypes.Add(i);

                    }

                }

            }

        }

        public System.String Mail

        {

            get

            {

                return _mail;

            }

            set

            {

                if (value != _mail)

                {

                    _mail = value;

                    OnPropertyChanged("mail");

                }

            }

        }

        public System.Nullable<System.Boolean> MailEnabled

        {

            get

            {

                return _mailEnabled;

            }

            set

            {

                if (value != _mailEnabled)

                {

                    _mailEnabled = value;

                    OnPropertyChanged("mailEnabled");

                }

            }

        }

        public System.String MailNickname

        {

            get

            {

                return _mailNickname;

            }

            set

            {

                if (value != _mailNickname)

                {

                    _mailNickname = value;

                    OnPropertyChanged("mailNickname");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> OnPremisesLastSyncDateTime

        {

            get

            {

                return _onPremisesLastSyncDateTime;

            }

            set

            {

                if (value != _onPremisesLastSyncDateTime)

                {

                    _onPremisesLastSyncDateTime = value;

                    OnPropertyChanged("onPremisesLastSyncDateTime");

                }

            }

        }

        public System.String OnPremisesSecurityIdentifier

        {

            get

            {

                return _onPremisesSecurityIdentifier;

            }

            set

            {

                if (value != _onPremisesSecurityIdentifier)

                {

                    _onPremisesSecurityIdentifier = value;

                    OnPropertyChanged("onPremisesSecurityIdentifier");

                }

            }

        }

        public System.Nullable<System.Boolean> OnPremisesSyncEnabled

        {

            get

            {

                return _onPremisesSyncEnabled;

            }

            set

            {

                if (value != _onPremisesSyncEnabled)

                {

                    _onPremisesSyncEnabled = value;

                    OnPropertyChanged("onPremisesSyncEnabled");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ProxyAddresses

        {

            get

            {

                if (this._proxyAddresses == default(System.Collections.Generic.IList<System.String>))

                {

                    this._proxyAddresses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._proxyAddresses.SetContainer(() => GetContainingEntity("proxyAddresses"));

                }

                return this._proxyAddresses;

            }

            set

            {

                ProxyAddresses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ProxyAddresses.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.Boolean> SecurityEnabled

        {

            get

            {

                return _securityEnabled;

            }

            set

            {

                if (value != _securityEnabled)

                {

                    _securityEnabled = value;

                    OnPropertyChanged("securityEnabled");

                }

            }

        }

        public System.String Visibility

        {

            get

            {

                return _visibility;

            }

            set

            {

                if (value != _visibility)

                {

                    _visibility = value;

                    OnPropertyChanged("visibility");

                }

            }

        }

        public global::Microsoft.Graph.GroupAccessType AccessType

        {

            get

            {

                return _accessType;

            }

            set

            {

                if (value != _accessType)

                {

                    _accessType = value;

                    OnPropertyChanged("accessType");

                }

            }

        }

        public System.Nullable<System.Boolean> AllowExternalSenders

        {

            get

            {

                return _allowExternalSenders;

            }

            set

            {

                if (value != _allowExternalSenders)

                {

                    _allowExternalSenders = value;

                    OnPropertyChanged("allowExternalSenders");

                }

            }

        }

        public System.Nullable<System.Boolean> AutoSubscribeNewMembers

        {

            get

            {

                return _autoSubscribeNewMembers;

            }

            set

            {

                if (value != _autoSubscribeNewMembers)

                {

                    _autoSubscribeNewMembers = value;

                    OnPropertyChanged("autoSubscribeNewMembers");

                }

            }

        }

        public System.Nullable<System.Boolean> IsFavorite

        {

            get

            {

                return _isFavorite;

            }

            set

            {

                if (value != _isFavorite)

                {

                    _isFavorite = value;

                    OnPropertyChanged("isFavorite");

                }

            }

        }

        public System.Nullable<System.Boolean> IsSubscribedByMail

        {

            get

            {

                return _isSubscribedByMail;

            }

            set

            {

                if (value != _isSubscribedByMail)

                {

                    _isSubscribedByMail = value;

                    OnPropertyChanged("isSubscribedByMail");

                }

            }

        }

        public System.Nullable<System.Int32> UnseenCount

        {

            get

            {

                return _unseenCount;

            }

            set

            {

                if (value != _unseenCount)

                {

                    _unseenCount = value;

                    OnPropertyChanged("unseenCount");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IGroup.Members

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)Members);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IGroup.MemberOf

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)MemberOf);

            }

        }

        global::Microsoft.Graph.IDirectoryObject global::Microsoft.Graph.IGroup.CreatedOnBehalfOf

        {

            get

            {

                return this._createdOnBehalfOf;

            }

            set

            {

                if (this.CreatedOnBehalfOf != value)

                {

                    this.CreatedOnBehalfOf = (global::Microsoft.Graph.DirectoryObject)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IGroup.Owners

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)Owners);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IConversationThread> global::Microsoft.Graph.IGroup.Threads

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IConversationThread, global::Microsoft.Graph.ConversationThread>(Context, (DataServiceCollection<global::Microsoft.Graph.ConversationThread>)Threads);

            }

        }

        global::Microsoft.Graph.ICalendar global::Microsoft.Graph.IGroup.Calendar

        {

            get

            {

                return this._calendar;

            }

            set

            {

                if (this.Calendar != value)

                {

                    this.Calendar = (global::Microsoft.Graph.Calendar)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.IGroup.CalendarView

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)CalendarView);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.IGroup.Events

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)Events);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IConversation> global::Microsoft.Graph.IGroup.Conversations

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IConversation, global::Microsoft.Graph.Conversation>(Context, (DataServiceCollection<global::Microsoft.Graph.Conversation>)Conversations);

            }

        }

        global::Microsoft.Graph.IProfilePhoto global::Microsoft.Graph.IGroup.Photo

        {

            get

            {

                return this._photo;

            }

            set

            {

                if (this.Photo != value)

                {

                    this.Photo = (global::Microsoft.Graph.ProfilePhoto)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IProfilePhoto> global::Microsoft.Graph.IGroup.Photos

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IProfilePhoto, global::Microsoft.Graph.ProfilePhoto>(Context, (DataServiceCollection<global::Microsoft.Graph.ProfilePhoto>)Photos);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IGroup.AcceptedSenders

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)AcceptedSenders);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IGroup.RejectedSenders

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)RejectedSenders);

            }

        }

        global::Microsoft.Graph.IDrive global::Microsoft.Graph.IGroup.Drive

        {

            get

            {

                return this._drive;

            }

            set

            {

                if (this.Drive != value)

                {

                    this.Drive = (global::Microsoft.Graph.Drive)value;

                }

            }

        }

        global::Microsoft.Graph.INotes global::Microsoft.Graph.IGroup.Notes

        {

            get

            {

                return this._notes;

            }

            set

            {

                if (this.Notes != value)

                {

                    this.Notes = (global::Microsoft.Graph.Notes)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPlan> global::Microsoft.Graph.IGroup.Plans

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IPlan, global::Microsoft.Graph.Plan>(Context, (DataServiceCollection<global::Microsoft.Graph.Plan>)Plans);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Description instead.")]

        public System.String description

        {

            get

            {

                return Description;

            }

            set

            {

                Description = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use GroupTypes instead.")]

        public global::System.Collections.Generic.IList<System.String> groupTypes

        {

            get

            {

                return GroupTypes;

            }

            set

            {

                GroupTypes = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Mail instead.")]

        public System.String mail

        {

            get

            {

                return Mail;

            }

            set

            {

                Mail = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MailEnabled instead.")]

        public System.Nullable<System.Boolean> mailEnabled

        {

            get

            {

                return MailEnabled;

            }

            set

            {

                MailEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MailNickname instead.")]

        public System.String mailNickname

        {

            get

            {

                return MailNickname;

            }

            set

            {

                MailNickname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesLastSyncDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> onPremisesLastSyncDateTime

        {

            get

            {

                return OnPremisesLastSyncDateTime;

            }

            set

            {

                OnPremisesLastSyncDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSecurityIdentifier instead.")]

        public System.String onPremisesSecurityIdentifier

        {

            get

            {

                return OnPremisesSecurityIdentifier;

            }

            set

            {

                OnPremisesSecurityIdentifier = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSyncEnabled instead.")]

        public System.Nullable<System.Boolean> onPremisesSyncEnabled

        {

            get

            {

                return OnPremisesSyncEnabled;

            }

            set

            {

                OnPremisesSyncEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProxyAddresses instead.")]

        public global::System.Collections.Generic.IList<System.String> proxyAddresses

        {

            get

            {

                return ProxyAddresses;

            }

            set

            {

                ProxyAddresses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SecurityEnabled instead.")]

        public System.Nullable<System.Boolean> securityEnabled

        {

            get

            {

                return SecurityEnabled;

            }

            set

            {

                SecurityEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Visibility instead.")]

        public System.String visibility

        {

            get

            {

                return Visibility;

            }

            set

            {

                Visibility = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AccessType instead.")]

        public global::Microsoft.Graph.GroupAccessType accessType

        {

            get

            {

                return AccessType;

            }

            set

            {

                AccessType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AllowExternalSenders instead.")]

        public System.Nullable<System.Boolean> allowExternalSenders

        {

            get

            {

                return AllowExternalSenders;

            }

            set

            {

                AllowExternalSenders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AutoSubscribeNewMembers instead.")]

        public System.Nullable<System.Boolean> autoSubscribeNewMembers

        {

            get

            {

                return AutoSubscribeNewMembers;

            }

            set

            {

                AutoSubscribeNewMembers = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsFavorite instead.")]

        public System.Nullable<System.Boolean> isFavorite

        {

            get

            {

                return IsFavorite;

            }

            set

            {

                IsFavorite = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsSubscribedByMail instead.")]

        public System.Nullable<System.Boolean> isSubscribedByMail

        {

            get

            {

                return IsSubscribedByMail;

            }

            set

            {

                IsSubscribedByMail = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UnseenCount instead.")]

        public System.Nullable<System.Int32> unseenCount

        {

            get

            {

                return UnseenCount;

            }

            set

            {

                UnseenCount = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Members instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> members

        {

            get

            {

                return Members;

            }

            set

            {

                Members = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MemberOf instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> memberOf

        {

            get

            {

                return MemberOf;

            }

            set

            {

                MemberOf = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedOnBehalfOf instead.")]

        public global::Microsoft.Graph.DirectoryObject createdOnBehalfOf

        {

            get

            {

                return CreatedOnBehalfOf;

            }

            set

            {

                CreatedOnBehalfOf = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Owners instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> owners

        {

            get

            {

                return Owners;

            }

            set

            {

                Owners = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Threads instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ConversationThread> threads

        {

            get

            {

                return Threads;

            }

            set

            {

                Threads = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Calendar instead.")]

        public global::Microsoft.Graph.Calendar calendar

        {

            get

            {

                return Calendar;

            }

            set

            {

                Calendar = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CalendarView instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> calendarView

        {

            get

            {

                return CalendarView;

            }

            set

            {

                CalendarView = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Events instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> events

        {

            get

            {

                return Events;

            }

            set

            {

                Events = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Conversations instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Conversation> conversations

        {

            get

            {

                return Conversations;

            }

            set

            {

                Conversations = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Photo instead.")]

        public global::Microsoft.Graph.ProfilePhoto photo

        {

            get

            {

                return Photo;

            }

            set

            {

                Photo = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Photos instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ProfilePhoto> photos

        {

            get

            {

                return Photos;

            }

            set

            {

                Photos = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AcceptedSenders instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> acceptedSenders

        {

            get

            {

                return AcceptedSenders;

            }

            set

            {

                AcceptedSenders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RejectedSenders instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> rejectedSenders

        {

            get

            {

                return RejectedSenders;

            }

            set

            {

                RejectedSenders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Drive instead.")]

        public global::Microsoft.Graph.Drive drive

        {

            get

            {

                return Drive;

            }

            set

            {

                Drive = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Notes instead.")]

        public global::Microsoft.Graph.Notes notes

        {

            get

            {

                return Notes;

            }

            set

            {

                Notes = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Plans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Plan> plans

        {

            get

            {

                return Plans;

            }

            set

            {

                Plans = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> Members

        {

            get

            {

                if (this._membersConcrete == null)

                {

                    this._membersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._membersConcrete.SetContainer(() => GetContainingEntity("members"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._membersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Members.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Members.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> MemberOf

        {

            get

            {

                if (this._memberOfConcrete == null)

                {

                    this._memberOfConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._memberOfConcrete.SetContainer(() => GetContainingEntity("memberOf"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._memberOfConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                MemberOf.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        MemberOf.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.DirectoryObject CreatedOnBehalfOf

        {

            get

            {

                return this._createdOnBehalfOf;

            }

            set

            {

                if (this._createdOnBehalfOf != value)

                {

                    this._createdOnBehalfOf = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "createdOnBehalfOf", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> Owners

        {

            get

            {

                if (this._ownersConcrete == null)

                {

                    this._ownersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._ownersConcrete.SetContainer(() => GetContainingEntity("owners"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._ownersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Owners.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Owners.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ConversationThread> Threads

        {

            get

            {

                if (this._threadsConcrete == null)

                {

                    this._threadsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ConversationThread>();

                    this._threadsConcrete.SetContainer(() => GetContainingEntity("threads"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.ConversationThread>)this._threadsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Threads.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Threads.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Calendar Calendar

        {

            get

            {

                return this._calendar;

            }

            set

            {

                if (this._calendar != value)

                {

                    this._calendar = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "calendar", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> CalendarView

        {

            get

            {

                if (this._calendarViewConcrete == null)

                {

                    this._calendarViewConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._calendarViewConcrete.SetContainer(() => GetContainingEntity("calendarView"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._calendarViewConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                CalendarView.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CalendarView.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> Events

        {

            get

            {

                if (this._eventsConcrete == null)

                {

                    this._eventsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._eventsConcrete.SetContainer(() => GetContainingEntity("events"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._eventsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Events.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Events.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Conversation> Conversations

        {

            get

            {

                if (this._conversationsConcrete == null)

                {

                    this._conversationsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Conversation>();

                    this._conversationsConcrete.SetContainer(() => GetContainingEntity("conversations"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Conversation>)this._conversationsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Conversations.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Conversations.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.ProfilePhoto Photo

        {

            get

            {

                return this._photo;

            }

            set

            {

                if (this._photo != value)

                {

                    this._photo = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "photo", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ProfilePhoto> Photos

        {

            get

            {

                if (this._photosConcrete == null)

                {

                    this._photosConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ProfilePhoto>();

                    this._photosConcrete.SetContainer(() => GetContainingEntity("photos"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.ProfilePhoto>)this._photosConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Photos.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Photos.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> AcceptedSenders

        {

            get

            {

                if (this._acceptedSendersConcrete == null)

                {

                    this._acceptedSendersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._acceptedSendersConcrete.SetContainer(() => GetContainingEntity("acceptedSenders"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._acceptedSendersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                AcceptedSenders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AcceptedSenders.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> RejectedSenders

        {

            get

            {

                if (this._rejectedSendersConcrete == null)

                {

                    this._rejectedSendersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._rejectedSendersConcrete.SetContainer(() => GetContainingEntity("rejectedSenders"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._rejectedSendersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                RejectedSenders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        RejectedSenders.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Drive Drive

        {

            get

            {

                return this._drive;

            }

            set

            {

                if (this._drive != value)

                {

                    this._drive = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "drive", value);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Notes Notes

        {

            get

            {

                return this._notes;

            }

            set

            {

                if (this._notes != value)

                {

                    this._notes = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "notes", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Plan> Plans

        {

            get

            {

                if (this._plansConcrete == null)

                {

                    this._plansConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Plan>();

                    this._plansConcrete.SetContainer(() => GetContainingEntity("plans"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Plan>)this._plansConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Plans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Plans.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IGroupFetcher.Members

        {

            get

            {

                if (this._membersCollection == null)

                {

                    this._membersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("members")) : null,
                       Context,
                       this,
                       GetPath("members"));

                }



                return this._membersCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IGroupFetcher.MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectFetcher global::Microsoft.Graph.IGroupFetcher.CreatedOnBehalfOf

        {

            get

            {

                if (this._createdOnBehalfOfFetcher == null)

                {

                    this._createdOnBehalfOfFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._createdOnBehalfOfFetcher.Initialize(this.Context, GetPath("createdOnBehalfOf"));

                }



                return this._createdOnBehalfOfFetcher;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IGroupFetcher.Owners

        {

            get

            {

                if (this._ownersCollection == null)

                {

                    this._ownersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("owners")) : null,
                       Context,
                       this,
                       GetPath("owners"));

                }



                return this._ownersCollection;

            }

        }

        global::Microsoft.Graph.IConversationThreadCollection global::Microsoft.Graph.IGroupFetcher.Threads

        {

            get

            {

                if (this._threadsCollection == null)

                {

                    this._threadsCollection = new global::Microsoft.Graph.ConversationThreadCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ConversationThread>(GetPath("threads")) : null,
                       Context,
                       this,
                       GetPath("threads"));

                }



                return this._threadsCollection;

            }

        }

        global::Microsoft.Graph.ICalendarFetcher global::Microsoft.Graph.IGroupFetcher.Calendar

        {

            get

            {

                if (this._calendarFetcher == null)

                {

                    this._calendarFetcher = new global::Microsoft.Graph.CalendarFetcher();

                    this._calendarFetcher.Initialize(this.Context, GetPath("calendar"));

                }



                return this._calendarFetcher;

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.IGroupFetcher.CalendarView

        {

            get

            {

                if (this._calendarViewCollection == null)

                {

                    this._calendarViewCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("calendarView")) : null,
                       Context,
                       this,
                       GetPath("calendarView"));

                }



                return this._calendarViewCollection;

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.IGroupFetcher.Events

        {

            get

            {

                if (this._eventsCollection == null)

                {

                    this._eventsCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("events")) : null,
                       Context,
                       this,
                       GetPath("events"));

                }



                return this._eventsCollection;

            }

        }

        global::Microsoft.Graph.IConversationCollection global::Microsoft.Graph.IGroupFetcher.Conversations

        {

            get

            {

                if (this._conversationsCollection == null)

                {

                    this._conversationsCollection = new global::Microsoft.Graph.ConversationCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Conversation>(GetPath("conversations")) : null,
                       Context,
                       this,
                       GetPath("conversations"));

                }



                return this._conversationsCollection;

            }

        }

        global::Microsoft.Graph.IProfilePhotoFetcher global::Microsoft.Graph.IGroupFetcher.Photo

        {

            get

            {

                if (this._photoFetcher == null)

                {

                    this._photoFetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                    this._photoFetcher.Initialize(this.Context, GetPath("photo"));

                }



                return this._photoFetcher;

            }

        }

        global::Microsoft.Graph.IProfilePhotoCollection global::Microsoft.Graph.IGroupFetcher.Photos

        {

            get

            {

                if (this._photosCollection == null)

                {

                    this._photosCollection = new global::Microsoft.Graph.ProfilePhotoCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ProfilePhoto>(GetPath("photos")) : null,
                       Context,
                       this,
                       GetPath("photos"));

                }



                return this._photosCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IGroupFetcher.AcceptedSenders

        {

            get

            {

                if (this._acceptedSendersCollection == null)

                {

                    this._acceptedSendersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("acceptedSenders")) : null,
                       Context,
                       this,
                       GetPath("acceptedSenders"));

                }



                return this._acceptedSendersCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IGroupFetcher.RejectedSenders

        {

            get

            {

                if (this._rejectedSendersCollection == null)

                {

                    this._rejectedSendersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("rejectedSenders")) : null,
                       Context,
                       this,
                       GetPath("rejectedSenders"));

                }



                return this._rejectedSendersCollection;

            }

        }

        global::Microsoft.Graph.IDriveFetcher global::Microsoft.Graph.IGroupFetcher.Drive

        {

            get

            {

                if (this._driveFetcher == null)

                {

                    this._driveFetcher = new global::Microsoft.Graph.DriveFetcher();

                    this._driveFetcher.Initialize(this.Context, GetPath("drive"));

                }



                return this._driveFetcher;

            }

        }

        global::Microsoft.Graph.INotesFetcher global::Microsoft.Graph.IGroupFetcher.Notes

        {

            get

            {

                if (this._notesFetcher == null)

                {

                    this._notesFetcher = new global::Microsoft.Graph.NotesFetcher();

                    this._notesFetcher.Initialize(this.Context, GetPath("notes"));

                }



                return this._notesFetcher;

            }

        }

        global::Microsoft.Graph.IPlanCollection global::Microsoft.Graph.IGroupFetcher.Plans

        {

            get

            {

                if (this._plansCollection == null)

                {

                    this._plansCollection = new global::Microsoft.Graph.PlanCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Plan>(GetPath("plans")) : null,
                       Context,
                       this,
                       GetPath("plans"));

                }



                return this._plansCollection;

            }

        }

        public Group()

        {

        }

        public async System.Threading.Tasks.Task subscribeByMailAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/subscribeByMail");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task unsubscribeByMailAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/unsubscribeByMail");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task addFavoriteAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/addFavorite");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task removeFavoriteAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/removeFavorite");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task resetUnseenCountAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/resetUnseenCount");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IGroup> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Group, global::Microsoft.Graph.IGroup>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IGroup> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IGroup> global::Microsoft.Graph.IGroupFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IGroup>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IGroupFetcher global::Microsoft.Graph.IGroupFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IGroup, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IGroupFetcher)this;

        }

    }

    internal partial class GroupFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IGroupFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectFetcher _createdOnBehalfOfFetcher;

        private global::Microsoft.Graph.CalendarFetcher _calendarFetcher;

        private global::Microsoft.Graph.ProfilePhotoFetcher _photoFetcher;

        private global::Microsoft.Graph.DriveFetcher _driveFetcher;

        private global::Microsoft.Graph.NotesFetcher _notesFetcher;

        private global::Microsoft.Graph.DirectoryObjectCollection _membersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownersCollection;

        private global::Microsoft.Graph.ConversationThreadCollection _threadsCollection;

        private global::Microsoft.Graph.EventCollection _calendarViewCollection;

        private global::Microsoft.Graph.EventCollection _eventsCollection;

        private global::Microsoft.Graph.ConversationCollection _conversationsCollection;

        private global::Microsoft.Graph.ProfilePhotoCollection _photosCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _acceptedSendersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _rejectedSendersCollection;

        private global::Microsoft.Graph.PlanCollection _plansCollection;

        public global::Microsoft.Graph.IDirectoryObjectCollection Members

        {

            get

            {

                if (this._membersCollection == null)

                {

                    this._membersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("members")) : null,
                       Context,
                       this,
                       GetPath("members"));

                }



                return this._membersCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectFetcher CreatedOnBehalfOf

        {

            get

            {

                if (this._createdOnBehalfOfFetcher == null)

                {

                    this._createdOnBehalfOfFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._createdOnBehalfOfFetcher.Initialize(this.Context, GetPath("createdOnBehalfOf"));

                }



                return this._createdOnBehalfOfFetcher;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection Owners

        {

            get

            {

                if (this._ownersCollection == null)

                {

                    this._ownersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("owners")) : null,
                       Context,
                       this,
                       GetPath("owners"));

                }



                return this._ownersCollection;

            }

        }

        public global::Microsoft.Graph.IConversationThreadCollection Threads

        {

            get

            {

                if (this._threadsCollection == null)

                {

                    this._threadsCollection = new global::Microsoft.Graph.ConversationThreadCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ConversationThread>(GetPath("threads")) : null,
                       Context,
                       this,
                       GetPath("threads"));

                }



                return this._threadsCollection;

            }

        }

        public global::Microsoft.Graph.ICalendarFetcher Calendar

        {

            get

            {

                if (this._calendarFetcher == null)

                {

                    this._calendarFetcher = new global::Microsoft.Graph.CalendarFetcher();

                    this._calendarFetcher.Initialize(this.Context, GetPath("calendar"));

                }



                return this._calendarFetcher;

            }

        }

        public global::Microsoft.Graph.IEventCollection CalendarView

        {

            get

            {

                if (this._calendarViewCollection == null)

                {

                    this._calendarViewCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("calendarView")) : null,
                       Context,
                       this,
                       GetPath("calendarView"));

                }



                return this._calendarViewCollection;

            }

        }

        public global::Microsoft.Graph.IEventCollection Events

        {

            get

            {

                if (this._eventsCollection == null)

                {

                    this._eventsCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("events")) : null,
                       Context,
                       this,
                       GetPath("events"));

                }



                return this._eventsCollection;

            }

        }

        public global::Microsoft.Graph.IConversationCollection Conversations

        {

            get

            {

                if (this._conversationsCollection == null)

                {

                    this._conversationsCollection = new global::Microsoft.Graph.ConversationCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Conversation>(GetPath("conversations")) : null,
                       Context,
                       this,
                       GetPath("conversations"));

                }



                return this._conversationsCollection;

            }

        }

        public global::Microsoft.Graph.IProfilePhotoFetcher Photo

        {

            get

            {

                if (this._photoFetcher == null)

                {

                    this._photoFetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                    this._photoFetcher.Initialize(this.Context, GetPath("photo"));

                }



                return this._photoFetcher;

            }

        }

        public global::Microsoft.Graph.IProfilePhotoCollection Photos

        {

            get

            {

                if (this._photosCollection == null)

                {

                    this._photosCollection = new global::Microsoft.Graph.ProfilePhotoCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ProfilePhoto>(GetPath("photos")) : null,
                       Context,
                       this,
                       GetPath("photos"));

                }



                return this._photosCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection AcceptedSenders

        {

            get

            {

                if (this._acceptedSendersCollection == null)

                {

                    this._acceptedSendersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("acceptedSenders")) : null,
                       Context,
                       this,
                       GetPath("acceptedSenders"));

                }



                return this._acceptedSendersCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection RejectedSenders

        {

            get

            {

                if (this._rejectedSendersCollection == null)

                {

                    this._rejectedSendersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("rejectedSenders")) : null,
                       Context,
                       this,
                       GetPath("rejectedSenders"));

                }



                return this._rejectedSendersCollection;

            }

        }

        public global::Microsoft.Graph.IDriveFetcher Drive

        {

            get

            {

                if (this._driveFetcher == null)

                {

                    this._driveFetcher = new global::Microsoft.Graph.DriveFetcher();

                    this._driveFetcher.Initialize(this.Context, GetPath("drive"));

                }



                return this._driveFetcher;

            }

        }

        public global::Microsoft.Graph.INotesFetcher Notes

        {

            get

            {

                if (this._notesFetcher == null)

                {

                    this._notesFetcher = new global::Microsoft.Graph.NotesFetcher();

                    this._notesFetcher.Initialize(this.Context, GetPath("notes"));

                }



                return this._notesFetcher;

            }

        }

        public global::Microsoft.Graph.IPlanCollection Plans

        {

            get

            {

                if (this._plansCollection == null)

                {

                    this._plansCollection = new global::Microsoft.Graph.PlanCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Plan>(GetPath("plans")) : null,
                       Context,
                       this,
                       GetPath("plans"));

                }



                return this._plansCollection;

            }

        }

        public GroupFetcher()

        {

        }

        public async System.Threading.Tasks.Task subscribeByMailAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/subscribeByMail");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task unsubscribeByMailAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/unsubscribeByMail");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task addFavoriteAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/addFavorite");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task removeFavoriteAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/removeFavorite");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async System.Threading.Tasks.Task resetUnseenCountAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/resetUnseenCount");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IGroup> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IGroupFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IGroup, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IGroupFetcher)new global::Microsoft.Graph.GroupFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IGroup> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Group, global::Microsoft.Graph.IGroup>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IGroup> _query;

    }

    internal partial class GroupCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IGroup>, global::Microsoft.Graph.IGroupCollection

    {

        internal GroupCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IGroupFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IGroup>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddgroupAsync(global::Microsoft.Graph.IGroup item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IGroupFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Group>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.GroupFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class GroupCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class ConversationThread : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IConversationThread, global::Microsoft.Graph.IConversationThreadFetcher

    {

        private global::Microsoft.Graph.PostCollection _postsCollection;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient> _toRecipients;

        private System.String _topic;

        private System.Boolean _hasAttachments;

        private System.DateTimeOffset _lastDeliveredDateTime;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _uniqueSenders;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient> _ccRecipients;

        private System.String _preview;

        private System.Boolean _isLocked;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Post> _postsConcrete;

        public System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> ToRecipients

        {

            get

            {

                if (this._toRecipients == default(System.Collections.Generic.IList<global::Microsoft.Graph.Recipient>))

                {

                    this._toRecipients = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient>();

                    this._toRecipients.SetContainer(() => GetContainingEntity("toRecipients"));

                }

                return this._toRecipients;

            }

            set

            {

                ToRecipients.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ToRecipients.Add(i);

                    }

                }

            }

        }

        public System.String Topic

        {

            get

            {

                return _topic;

            }

            set

            {

                if (value != _topic)

                {

                    _topic = value;

                    OnPropertyChanged("topic");

                }

            }

        }

        public System.Boolean HasAttachments

        {

            get

            {

                return _hasAttachments;

            }

            set

            {

                if (value != _hasAttachments)

                {

                    _hasAttachments = value;

                    OnPropertyChanged("hasAttachments");

                }

            }

        }

        public System.DateTimeOffset LastDeliveredDateTime

        {

            get

            {

                return _lastDeliveredDateTime;

            }

            set

            {

                if (value != _lastDeliveredDateTime)

                {

                    _lastDeliveredDateTime = value;

                    OnPropertyChanged("lastDeliveredDateTime");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> UniqueSenders

        {

            get

            {

                if (this._uniqueSenders == default(System.Collections.Generic.IList<System.String>))

                {

                    this._uniqueSenders = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._uniqueSenders.SetContainer(() => GetContainingEntity("uniqueSenders"));

                }

                return this._uniqueSenders;

            }

            set

            {

                UniqueSenders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        UniqueSenders.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> CcRecipients

        {

            get

            {

                if (this._ccRecipients == default(System.Collections.Generic.IList<global::Microsoft.Graph.Recipient>))

                {

                    this._ccRecipients = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient>();

                    this._ccRecipients.SetContainer(() => GetContainingEntity("ccRecipients"));

                }

                return this._ccRecipients;

            }

            set

            {

                CcRecipients.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CcRecipients.Add(i);

                    }

                }

            }

        }

        public System.String Preview

        {

            get

            {

                return _preview;

            }

            set

            {

                if (value != _preview)

                {

                    _preview = value;

                    OnPropertyChanged("preview");

                }

            }

        }

        public System.Boolean IsLocked

        {

            get

            {

                return _isLocked;

            }

            set

            {

                if (value != _isLocked)

                {

                    _isLocked = value;

                    OnPropertyChanged("isLocked");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPost> global::Microsoft.Graph.IConversationThread.Posts

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IPost, global::Microsoft.Graph.Post>(Context, (DataServiceCollection<global::Microsoft.Graph.Post>)Posts);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ToRecipients instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> toRecipients

        {

            get

            {

                return ToRecipients;

            }

            set

            {

                ToRecipients = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Topic instead.")]

        public System.String topic

        {

            get

            {

                return Topic;

            }

            set

            {

                Topic = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HasAttachments instead.")]

        public System.Boolean hasAttachments

        {

            get

            {

                return HasAttachments;

            }

            set

            {

                HasAttachments = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastDeliveredDateTime instead.")]

        public System.DateTimeOffset lastDeliveredDateTime

        {

            get

            {

                return LastDeliveredDateTime;

            }

            set

            {

                LastDeliveredDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UniqueSenders instead.")]

        public global::System.Collections.Generic.IList<System.String> uniqueSenders

        {

            get

            {

                return UniqueSenders;

            }

            set

            {

                UniqueSenders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CcRecipients instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> ccRecipients

        {

            get

            {

                return CcRecipients;

            }

            set

            {

                CcRecipients = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Preview instead.")]

        public System.String preview

        {

            get

            {

                return Preview;

            }

            set

            {

                Preview = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsLocked instead.")]

        public System.Boolean isLocked

        {

            get

            {

                return IsLocked;

            }

            set

            {

                IsLocked = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Posts instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Post> posts

        {

            get

            {

                return Posts;

            }

            set

            {

                Posts = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Post> Posts

        {

            get

            {

                if (this._postsConcrete == null)

                {

                    this._postsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Post>();

                    this._postsConcrete.SetContainer(() => GetContainingEntity("posts"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Post>)this._postsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Posts.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Posts.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IPostCollection global::Microsoft.Graph.IConversationThreadFetcher.Posts

        {

            get

            {

                if (this._postsCollection == null)

                {

                    this._postsCollection = new global::Microsoft.Graph.PostCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Post>(GetPath("posts")) : null,
                       Context,
                       this,
                       GetPath("posts"));

                }



                return this._postsCollection;

            }

        }

        public ConversationThread() : base()

        {

        }

        public async System.Threading.Tasks.Task replyAsync(global::Microsoft.Graph.IPost Post)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/reply");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("Post", (object) Post),

            }

            );

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversationThread> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ConversationThread, global::Microsoft.Graph.IConversationThread>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversationThread> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IConversationThread> global::Microsoft.Graph.IConversationThreadFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IConversationThread>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IConversationThreadFetcher global::Microsoft.Graph.IConversationThreadFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IConversationThread, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IConversationThreadFetcher)this;

        }

    }

    internal partial class ConversationThreadFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IConversationThreadFetcher

    {

        private global::Microsoft.Graph.PostCollection _postsCollection;

        public global::Microsoft.Graph.IPostCollection Posts

        {

            get

            {

                if (this._postsCollection == null)

                {

                    this._postsCollection = new global::Microsoft.Graph.PostCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Post>(GetPath("posts")) : null,
                       Context,
                       this,
                       GetPath("posts"));

                }



                return this._postsCollection;

            }

        }

        public ConversationThreadFetcher() : base()

        {

        }

        public async System.Threading.Tasks.Task replyAsync(global::Microsoft.Graph.IPost Post)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/reply");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("Post", (object) Post),

            }

            );

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IConversationThread> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IConversationThreadFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IConversationThread, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IConversationThreadFetcher)new global::Microsoft.Graph.ConversationThreadFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversationThread> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ConversationThread, global::Microsoft.Graph.IConversationThread>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversationThread> _query;

    }

    internal partial class ConversationThreadCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IConversationThread>, global::Microsoft.Graph.IConversationThreadCollection

    {

        internal ConversationThreadCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IConversationThreadFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IConversationThread>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddconversationThreadAsync(global::Microsoft.Graph.IConversationThread item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IConversationThreadFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.ConversationThread>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.ConversationThreadFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class ConversationThreadCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Calendar : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.ICalendar, global::Microsoft.Graph.ICalendarFetcher

    {

        private global::Microsoft.Graph.EventCollection _eventsCollection;

        private global::Microsoft.Graph.EventCollection _calendarViewCollection;

        private System.String _name;

        private global::Microsoft.Graph.CalendarColor _color;

        private System.String _changeKey;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _eventsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _calendarViewConcrete;

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        public global::Microsoft.Graph.CalendarColor Color

        {

            get

            {

                return _color;

            }

            set

            {

                if (value != _color)

                {

                    _color = value;

                    OnPropertyChanged("color");

                }

            }

        }

        public System.String ChangeKey

        {

            get

            {

                return _changeKey;

            }

            set

            {

                if (value != _changeKey)

                {

                    _changeKey = value;

                    OnPropertyChanged("changeKey");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.ICalendar.Events

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)Events);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.ICalendar.CalendarView

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)CalendarView);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Color instead.")]

        public global::Microsoft.Graph.CalendarColor color

        {

            get

            {

                return Color;

            }

            set

            {

                Color = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChangeKey instead.")]

        public System.String changeKey

        {

            get

            {

                return ChangeKey;

            }

            set

            {

                ChangeKey = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Events instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> events

        {

            get

            {

                return Events;

            }

            set

            {

                Events = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CalendarView instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> calendarView

        {

            get

            {

                return CalendarView;

            }

            set

            {

                CalendarView = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> Events

        {

            get

            {

                if (this._eventsConcrete == null)

                {

                    this._eventsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._eventsConcrete.SetContainer(() => GetContainingEntity("events"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._eventsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Events.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Events.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> CalendarView

        {

            get

            {

                if (this._calendarViewConcrete == null)

                {

                    this._calendarViewConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._calendarViewConcrete.SetContainer(() => GetContainingEntity("calendarView"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._calendarViewConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                CalendarView.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CalendarView.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.ICalendarFetcher.Events

        {

            get

            {

                if (this._eventsCollection == null)

                {

                    this._eventsCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("events")) : null,
                       Context,
                       this,
                       GetPath("events"));

                }



                return this._eventsCollection;

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.ICalendarFetcher.CalendarView

        {

            get

            {

                if (this._calendarViewCollection == null)

                {

                    this._calendarViewCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("calendarView")) : null,
                       Context,
                       this,
                       GetPath("calendarView"));

                }



                return this._calendarViewCollection;

            }

        }

        public Calendar() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendar> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Calendar, global::Microsoft.Graph.ICalendar>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendar> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.ICalendar> global::Microsoft.Graph.ICalendarFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.ICalendar>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.ICalendarFetcher global::Microsoft.Graph.ICalendarFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.ICalendar, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.ICalendarFetcher)this;

        }

    }

    internal partial class CalendarFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.ICalendarFetcher

    {

        private global::Microsoft.Graph.EventCollection _eventsCollection;

        private global::Microsoft.Graph.EventCollection _calendarViewCollection;

        public global::Microsoft.Graph.IEventCollection Events

        {

            get

            {

                if (this._eventsCollection == null)

                {

                    this._eventsCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("events")) : null,
                       Context,
                       this,
                       GetPath("events"));

                }



                return this._eventsCollection;

            }

        }

        public global::Microsoft.Graph.IEventCollection CalendarView

        {

            get

            {

                if (this._calendarViewCollection == null)

                {

                    this._calendarViewCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("calendarView")) : null,
                       Context,
                       this,
                       GetPath("calendarView"));

                }



                return this._calendarViewCollection;

            }

        }

        public CalendarFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.ICalendar> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.ICalendarFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.ICalendar, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.ICalendarFetcher)new global::Microsoft.Graph.CalendarFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendar> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Calendar, global::Microsoft.Graph.ICalendar>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendar> _query;

    }

    internal partial class CalendarCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.ICalendar>, global::Microsoft.Graph.ICalendarCollection

    {

        internal CalendarCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.ICalendarFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ICalendar>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddcalendarAsync(global::Microsoft.Graph.ICalendar item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.ICalendarFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Calendar>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.CalendarFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class CalendarCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public abstract partial class OutlookItem : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IOutlookItem, global::Microsoft.Graph.IOutlookItemFetcher

    {

        private System.Nullable<System.DateTimeOffset> _createdDateTime;

        private System.Nullable<System.DateTimeOffset> _lastModifiedDateTime;

        private System.String _changeKey;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _categories;

        private System.String _id;

        public System.Nullable<System.DateTimeOffset> CreatedDateTime

        {

            get

            {

                return _createdDateTime;

            }

            set

            {

                if (value != _createdDateTime)

                {

                    _createdDateTime = value;

                    OnPropertyChanged("createdDateTime");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> LastModifiedDateTime

        {

            get

            {

                return _lastModifiedDateTime;

            }

            set

            {

                if (value != _lastModifiedDateTime)

                {

                    _lastModifiedDateTime = value;

                    OnPropertyChanged("lastModifiedDateTime");

                }

            }

        }

        public System.String ChangeKey

        {

            get

            {

                return _changeKey;

            }

            set

            {

                if (value != _changeKey)

                {

                    _changeKey = value;

                    OnPropertyChanged("changeKey");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Categories

        {

            get

            {

                if (this._categories == default(System.Collections.Generic.IList<System.String>))

                {

                    this._categories = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._categories.SetContainer(() => GetContainingEntity("categories"));

                }

                return this._categories;

            }

            set

            {

                Categories.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Categories.Add(i);

                    }

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> createdDateTime

        {

            get

            {

                return CreatedDateTime;

            }

            set

            {

                CreatedDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastModifiedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> lastModifiedDateTime

        {

            get

            {

                return LastModifiedDateTime;

            }

            set

            {

                LastModifiedDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChangeKey instead.")]

        public System.String changeKey

        {

            get

            {

                return ChangeKey;

            }

            set

            {

                ChangeKey = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Categories instead.")]

        public global::System.Collections.Generic.IList<System.String> categories

        {

            get

            {

                return Categories;

            }

            set

            {

                Categories = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        public OutlookItem() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOutlookItem> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.OutlookItem, global::Microsoft.Graph.IOutlookItem>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOutlookItem> _query;

    }

    internal partial class OutlookItemFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IOutlookItemFetcher

    {

        public OutlookItemFetcher() : base()

        {

        }

    }

    internal partial class OutlookItemCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IOutlookItem>, global::Microsoft.Graph.IOutlookItemCollection

    {

        internal OutlookItemCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IOutlookItemFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IOutlookItem>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddoutlookItemAsync(global::Microsoft.Graph.IOutlookItem item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IOutlookItemFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.OutlookItem>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.OutlookItemFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class OutlookItemCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Event : global::Microsoft.Graph.OutlookItem, global::Microsoft.Graph.IEvent, global::Microsoft.Graph.IEventFetcher

    {

        private global::Microsoft.Graph.Calendar _calendar;

        private global::Microsoft.Graph.CalendarFetcher _calendarFetcher;

        private global::Microsoft.Graph.EventCollection _instancesCollection;

        private global::Microsoft.Graph.ExtensionCollection _extensionsCollection;

        private global::Microsoft.Graph.AttachmentCollection _attachmentsCollection;

        private System.String _originalStartTimeZone;

        private System.String _originalEndTimeZone;

        private global::Microsoft.Graph.ResponseStatus _responseStatus;

        private System.String _iCalUId;

        private System.Nullable<System.Int32> _reminderMinutesBeforeStart;

        private System.Nullable<System.Boolean> _isReminderOn;

        private System.Nullable<System.Boolean> _hasAttachments;

        private System.String _subject;

        private global::Microsoft.Graph.ItemBody _body;

        private System.String _bodyPreview;

        private global::Microsoft.Graph.Importance _importance;

        private global::Microsoft.Graph.Sensitivity _sensitivity;

        private global::Microsoft.Graph.DateTimeTimeZone _start;

        private System.Nullable<System.DateTimeOffset> _originalStart;

        private global::Microsoft.Graph.DateTimeTimeZone _end;

        private global::Microsoft.Graph.Location _location;

        private System.Nullable<System.Boolean> _isAllDay;

        private System.Nullable<System.Boolean> _isCancelled;

        private System.Nullable<System.Boolean> _isOrganizer;

        private global::Microsoft.Graph.PatternedRecurrence _recurrence;

        private System.Nullable<System.Boolean> _responseRequested;

        private System.String _seriesMasterId;

        private global::Microsoft.Graph.FreeBusyStatus _showAs;

        private global::Microsoft.Graph.EventType _type;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Attendee> _attendees;

        private global::Microsoft.Graph.Recipient _organizer;

        private System.String _webLink;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _instancesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Extension> _extensionsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Attachment> _attachmentsConcrete;

        public System.String OriginalStartTimeZone

        {

            get

            {

                return _originalStartTimeZone;

            }

            set

            {

                if (value != _originalStartTimeZone)

                {

                    _originalStartTimeZone = value;

                    OnPropertyChanged("originalStartTimeZone");

                }

            }

        }

        public System.String OriginalEndTimeZone

        {

            get

            {

                return _originalEndTimeZone;

            }

            set

            {

                if (value != _originalEndTimeZone)

                {

                    _originalEndTimeZone = value;

                    OnPropertyChanged("originalEndTimeZone");

                }

            }

        }

        public global::Microsoft.Graph.ResponseStatus ResponseStatus

        {

            get

            {

                return _responseStatus;

            }

            set

            {

                if (value != _responseStatus)

                {

                    _responseStatus = value;

                    OnPropertyChanged("responseStatus");

                }

            }

        }

        public System.String ICalUId

        {

            get

            {

                return _iCalUId;

            }

            set

            {

                if (value != _iCalUId)

                {

                    _iCalUId = value;

                    OnPropertyChanged("iCalUId");

                }

            }

        }

        public System.Nullable<System.Int32> ReminderMinutesBeforeStart

        {

            get

            {

                return _reminderMinutesBeforeStart;

            }

            set

            {

                if (value != _reminderMinutesBeforeStart)

                {

                    _reminderMinutesBeforeStart = value;

                    OnPropertyChanged("reminderMinutesBeforeStart");

                }

            }

        }

        public System.Nullable<System.Boolean> IsReminderOn

        {

            get

            {

                return _isReminderOn;

            }

            set

            {

                if (value != _isReminderOn)

                {

                    _isReminderOn = value;

                    OnPropertyChanged("isReminderOn");

                }

            }

        }

        public System.Nullable<System.Boolean> HasAttachments

        {

            get

            {

                return _hasAttachments;

            }

            set

            {

                if (value != _hasAttachments)

                {

                    _hasAttachments = value;

                    OnPropertyChanged("hasAttachments");

                }

            }

        }

        public System.String Subject

        {

            get

            {

                return _subject;

            }

            set

            {

                if (value != _subject)

                {

                    _subject = value;

                    OnPropertyChanged("subject");

                }

            }

        }

        public global::Microsoft.Graph.ItemBody Body

        {

            get

            {

                return _body;

            }

            set

            {

                if (value != _body)

                {

                    _body = value;

                    OnPropertyChanged("body");

                }

            }

        }

        public System.String BodyPreview

        {

            get

            {

                return _bodyPreview;

            }

            set

            {

                if (value != _bodyPreview)

                {

                    _bodyPreview = value;

                    OnPropertyChanged("bodyPreview");

                }

            }

        }

        public global::Microsoft.Graph.Importance Importance

        {

            get

            {

                return _importance;

            }

            set

            {

                if (value != _importance)

                {

                    _importance = value;

                    OnPropertyChanged("importance");

                }

            }

        }

        //public global::Microsoft.Graph.Sensitivity Sensitivity

        //{

        //    get

        //    {

        //        return _sensitivity;

        //    }

        //    set

        //    {

        //        if (value != _sensitivity)

        //        {

        //            _sensitivity = value;

        //            OnPropertyChanged("sensitivity");

        //        }

        //    }

        //}

        public global::Microsoft.Graph.DateTimeTimeZone Start

        {

            get

            {

                return _start;

            }

            set

            {

                if (value != _start)

                {

                    _start = value;

                    OnPropertyChanged("start");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> OriginalStart

        {

            get

            {

                return _originalStart;

            }

            set

            {

                if (value != _originalStart)

                {

                    _originalStart = value;

                    OnPropertyChanged("originalStart");

                }

            }

        }

        public global::Microsoft.Graph.DateTimeTimeZone End

        {

            get

            {

                return _end;

            }

            set

            {

                if (value != _end)

                {

                    _end = value;

                    OnPropertyChanged("end");

                }

            }

        }

        public global::Microsoft.Graph.Location Location

        {

            get

            {

                return _location;

            }

            set

            {

                if (value != _location)

                {

                    _location = value;

                    OnPropertyChanged("location");

                }

            }

        }

        public System.Nullable<System.Boolean> IsAllDay

        {

            get

            {

                return _isAllDay;

            }

            set

            {

                if (value != _isAllDay)

                {

                    _isAllDay = value;

                    OnPropertyChanged("isAllDay");

                }

            }

        }

        public System.Nullable<System.Boolean> IsCancelled

        {

            get

            {

                return _isCancelled;

            }

            set

            {

                if (value != _isCancelled)

                {

                    _isCancelled = value;

                    OnPropertyChanged("isCancelled");

                }

            }

        }

        public System.Nullable<System.Boolean> IsOrganizer

        {

            get

            {

                return _isOrganizer;

            }

            set

            {

                if (value != _isOrganizer)

                {

                    _isOrganizer = value;

                    OnPropertyChanged("isOrganizer");

                }

            }

        }

        public global::Microsoft.Graph.PatternedRecurrence Recurrence

        {

            get

            {

                return _recurrence;

            }

            set

            {

                if (value != _recurrence)

                {

                    _recurrence = value;

                    OnPropertyChanged("recurrence");

                }

            }

        }

        public System.Nullable<System.Boolean> ResponseRequested

        {

            get

            {

                return _responseRequested;

            }

            set

            {

                if (value != _responseRequested)

                {

                    _responseRequested = value;

                    OnPropertyChanged("responseRequested");

                }

            }

        }

        public System.String SeriesMasterId

        {

            get

            {

                return _seriesMasterId;

            }

            set

            {

                if (value != _seriesMasterId)

                {

                    _seriesMasterId = value;

                    OnPropertyChanged("seriesMasterId");

                }

            }

        }

        public global::Microsoft.Graph.FreeBusyStatus ShowAs

        {

            get

            {

                return _showAs;

            }

            set

            {

                if (value != _showAs)

                {

                    _showAs = value;

                    OnPropertyChanged("showAs");

                }

            }

        }

        public global::Microsoft.Graph.EventType Type

        {

            get

            {

                return _type;

            }

            set

            {

                if (value != _type)

                {

                    _type = value;

                    OnPropertyChanged("type");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Attendee> Attendees

        {

            get

            {

                if (this._attendees == default(System.Collections.Generic.IList<global::Microsoft.Graph.Attendee>))

                {

                    this._attendees = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Attendee>();

                    this._attendees.SetContainer(() => GetContainingEntity("attendees"));

                }

                return this._attendees;

            }

            set

            {

                Attendees.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Attendees.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Recipient Organizer

        {

            get

            {

                return _organizer;

            }

            set

            {

                if (value != _organizer)

                {

                    _organizer = value;

                    OnPropertyChanged("organizer");

                }

            }

        }

        public System.String WebLink

        {

            get

            {

                return _webLink;

            }

            set

            {

                if (value != _webLink)

                {

                    _webLink = value;

                    OnPropertyChanged("webLink");

                }

            }

        }

        global::Microsoft.Graph.ICalendar global::Microsoft.Graph.IEvent.Calendar

        {

            get

            {

                return this._calendar;

            }

            set

            {

                if (this.Calendar != value)

                {

                    this.Calendar = (global::Microsoft.Graph.Calendar)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.IEvent.Instances

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)Instances);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IExtension> global::Microsoft.Graph.IEvent.Extensions

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IExtension, global::Microsoft.Graph.Extension>(Context, (DataServiceCollection<global::Microsoft.Graph.Extension>)Extensions);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IAttachment> global::Microsoft.Graph.IEvent.Attachments

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IAttachment, global::Microsoft.Graph.Attachment>(Context, (DataServiceCollection<global::Microsoft.Graph.Attachment>)Attachments);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OriginalStartTimeZone instead.")]

        public System.String originalStartTimeZone

        {

            get

            {

                return OriginalStartTimeZone;

            }

            set

            {

                OriginalStartTimeZone = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OriginalEndTimeZone instead.")]

        public System.String originalEndTimeZone

        {

            get

            {

                return OriginalEndTimeZone;

            }

            set

            {

                OriginalEndTimeZone = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResponseStatus instead.")]

        public global::Microsoft.Graph.ResponseStatus responseStatus

        {

            get

            {

                return ResponseStatus;

            }

            set

            {

                ResponseStatus = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ICalUId instead.")]

        public System.String iCalUId

        {

            get

            {

                return ICalUId;

            }

            set

            {

                ICalUId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ReminderMinutesBeforeStart instead.")]

        public System.Nullable<System.Int32> reminderMinutesBeforeStart

        {

            get

            {

                return ReminderMinutesBeforeStart;

            }

            set

            {

                ReminderMinutesBeforeStart = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsReminderOn instead.")]

        public System.Nullable<System.Boolean> isReminderOn

        {

            get

            {

                return IsReminderOn;

            }

            set

            {

                IsReminderOn = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HasAttachments instead.")]

        public System.Nullable<System.Boolean> hasAttachments

        {

            get

            {

                return HasAttachments;

            }

            set

            {

                HasAttachments = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Subject instead.")]

        public System.String subject

        {

            get

            {

                return Subject;

            }

            set

            {

                Subject = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Body instead.")]

        public global::Microsoft.Graph.ItemBody body

        {

            get

            {

                return Body;

            }

            set

            {

                Body = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BodyPreview instead.")]

        public System.String bodyPreview

        {

            get

            {

                return BodyPreview;

            }

            set

            {

                BodyPreview = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Importance instead.")]

        public global::Microsoft.Graph.Importance importance

        {

            get

            {

                return Importance;

            }

            set

            {

                Importance = value;

            }

        }

        //[EditorBrowsable(EditorBrowsableState.Never)]

        //[Obsolete("Use Sensitivity instead.")]

        //public global::Microsoft.Graph.Sensitivity sensitivity

        //{

        //    get

        //    {

        //        return Sensitivity;

        //    }

        //    set

        //    {

        //        Sensitivity = value;

        //    }

        //}

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Start instead.")]

        public global::Microsoft.Graph.DateTimeTimeZone start

        {

            get

            {

                return Start;

            }

            set

            {

                Start = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OriginalStart instead.")]

        public System.Nullable<System.DateTimeOffset> originalStart

        {

            get

            {

                return OriginalStart;

            }

            set

            {

                OriginalStart = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use End instead.")]

        public global::Microsoft.Graph.DateTimeTimeZone end

        {

            get

            {

                return End;

            }

            set

            {

                End = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Location instead.")]

        public global::Microsoft.Graph.Location location

        {

            get

            {

                return Location;

            }

            set

            {

                Location = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsAllDay instead.")]

        public System.Nullable<System.Boolean> isAllDay

        {

            get

            {

                return IsAllDay;

            }

            set

            {

                IsAllDay = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsCancelled instead.")]

        public System.Nullable<System.Boolean> isCancelled

        {

            get

            {

                return IsCancelled;

            }

            set

            {

                IsCancelled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsOrganizer instead.")]

        public System.Nullable<System.Boolean> isOrganizer

        {

            get

            {

                return IsOrganizer;

            }

            set

            {

                IsOrganizer = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Recurrence instead.")]

        public global::Microsoft.Graph.PatternedRecurrence recurrence

        {

            get

            {

                return Recurrence;

            }

            set

            {

                Recurrence = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResponseRequested instead.")]

        public System.Nullable<System.Boolean> responseRequested

        {

            get

            {

                return ResponseRequested;

            }

            set

            {

                ResponseRequested = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SeriesMasterId instead.")]

        public System.String seriesMasterId

        {

            get

            {

                return SeriesMasterId;

            }

            set

            {

                SeriesMasterId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ShowAs instead.")]

        public global::Microsoft.Graph.FreeBusyStatus showAs

        {

            get

            {

                return ShowAs;

            }

            set

            {

                ShowAs = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Type instead.")]

        public global::Microsoft.Graph.EventType type

        {

            get

            {

                return Type;

            }

            set

            {

                Type = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Attendees instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Attendee> attendees

        {

            get

            {

                return Attendees;

            }

            set

            {

                Attendees = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Organizer instead.")]

        public global::Microsoft.Graph.Recipient organizer

        {

            get

            {

                return Organizer;

            }

            set

            {

                Organizer = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use WebLink instead.")]

        public System.String webLink

        {

            get

            {

                return WebLink;

            }

            set

            {

                WebLink = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Calendar instead.")]

        public global::Microsoft.Graph.Calendar calendar

        {

            get

            {

                return Calendar;

            }

            set

            {

                Calendar = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Instances instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> instances

        {

            get

            {

                return Instances;

            }

            set

            {

                Instances = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Extensions instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension> extensions

        {

            get

            {

                return Extensions;

            }

            set

            {

                Extensions = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Attachments instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Attachment> attachments

        {

            get

            {

                return Attachments;

            }

            set

            {

                Attachments = value;

            }

        }

        public global::Microsoft.Graph.Calendar Calendar

        {

            get

            {

                return this._calendar;

            }

            set

            {

                if (this._calendar != value)

                {

                    this._calendar = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "calendar", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> Instances

        {

            get

            {

                if (this._instancesConcrete == null)

                {

                    this._instancesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._instancesConcrete.SetContainer(() => GetContainingEntity("instances"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._instancesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Instances.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Instances.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension> Extensions

        {

            get

            {

                if (this._extensionsConcrete == null)

                {

                    this._extensionsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Extension>();

                    this._extensionsConcrete.SetContainer(() => GetContainingEntity("extensions"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension>)this._extensionsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Extensions.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Extensions.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Attachment> Attachments

        {

            get

            {

                if (this._attachmentsConcrete == null)

                {

                    this._attachmentsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Attachment>();

                    this._attachmentsConcrete.SetContainer(() => GetContainingEntity("attachments"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Attachment>)this._attachmentsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Attachments.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Attachments.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.ICalendarFetcher global::Microsoft.Graph.IEventFetcher.Calendar

        {

            get

            {

                if (this._calendarFetcher == null)

                {

                    this._calendarFetcher = new global::Microsoft.Graph.CalendarFetcher();

                    this._calendarFetcher.Initialize(this.Context, GetPath("calendar"));

                }



                return this._calendarFetcher;

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.IEventFetcher.Instances

        {

            get

            {

                if (this._instancesCollection == null)

                {

                    this._instancesCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("instances")) : null,
                       Context,
                       this,
                       GetPath("instances"));

                }



                return this._instancesCollection;

            }

        }

        global::Microsoft.Graph.IExtensionCollection global::Microsoft.Graph.IEventFetcher.Extensions

        {

            get

            {

                if (this._extensionsCollection == null)

                {

                    this._extensionsCollection = new global::Microsoft.Graph.ExtensionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Extension>(GetPath("extensions")) : null,
                       Context,
                       this,
                       GetPath("extensions"));

                }



                return this._extensionsCollection;

            }

        }

        global::Microsoft.Graph.IAttachmentCollection global::Microsoft.Graph.IEventFetcher.Attachments

        {

            get

            {

                if (this._attachmentsCollection == null)

                {

                    this._attachmentsCollection = new global::Microsoft.Graph.AttachmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Attachment>(GetPath("attachments")) : null,
                       Context,
                       this,
                       GetPath("attachments"));

                }



                return this._attachmentsCollection;

            }

        }

        public Event()

        {

        }

        public async System.Threading.Tasks.Task acceptAsync(System.String Comment, System.Nullable<System.Boolean> SendResponse)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/accept");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("SendResponse", (object) SendResponse),

            }

            );

        }

        public async System.Threading.Tasks.Task declineAsync(System.String Comment, System.Nullable<System.Boolean> SendResponse)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/decline");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("SendResponse", (object) SendResponse),

            }

            );

        }

        public async System.Threading.Tasks.Task tentativelyAcceptAsync(System.String Comment, System.Nullable<System.Boolean> SendResponse)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/tentativelyAccept");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("SendResponse", (object) SendResponse),

            }

            );

        }

        public async System.Threading.Tasks.Task snoozeReminderAsync(global::Microsoft.Graph.DateTimeTimeZone NewReminderTime)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/snoozeReminder");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("NewReminderTime", (object) NewReminderTime),

            }

            );

        }

        public async System.Threading.Tasks.Task dismissReminderAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/dismissReminder");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IEvent> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Event, global::Microsoft.Graph.IEvent>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IEvent> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.IEventFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IEvent>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IEventFetcher global::Microsoft.Graph.IEventFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IEvent, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IEventFetcher)this;

        }

    }

    internal partial class EventFetcher : global::Microsoft.Graph.OutlookItemFetcher, global::Microsoft.Graph.IEventFetcher

    {

        private global::Microsoft.Graph.CalendarFetcher _calendarFetcher;

        private global::Microsoft.Graph.EventCollection _instancesCollection;

        private global::Microsoft.Graph.ExtensionCollection _extensionsCollection;

        private global::Microsoft.Graph.AttachmentCollection _attachmentsCollection;

        public global::Microsoft.Graph.ICalendarFetcher Calendar

        {

            get

            {

                if (this._calendarFetcher == null)

                {

                    this._calendarFetcher = new global::Microsoft.Graph.CalendarFetcher();

                    this._calendarFetcher.Initialize(this.Context, GetPath("calendar"));

                }



                return this._calendarFetcher;

            }

        }

        public global::Microsoft.Graph.IEventCollection Instances

        {

            get

            {

                if (this._instancesCollection == null)

                {

                    this._instancesCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("instances")) : null,
                       Context,
                       this,
                       GetPath("instances"));

                }



                return this._instancesCollection;

            }

        }

        public global::Microsoft.Graph.IExtensionCollection Extensions

        {

            get

            {

                if (this._extensionsCollection == null)

                {

                    this._extensionsCollection = new global::Microsoft.Graph.ExtensionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Extension>(GetPath("extensions")) : null,
                       Context,
                       this,
                       GetPath("extensions"));

                }



                return this._extensionsCollection;

            }

        }

        public global::Microsoft.Graph.IAttachmentCollection Attachments

        {

            get

            {

                if (this._attachmentsCollection == null)

                {

                    this._attachmentsCollection = new global::Microsoft.Graph.AttachmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Attachment>(GetPath("attachments")) : null,
                       Context,
                       this,
                       GetPath("attachments"));

                }



                return this._attachmentsCollection;

            }

        }

        public EventFetcher()

        {

        }

        public async System.Threading.Tasks.Task acceptAsync(System.String Comment, System.Nullable<System.Boolean> SendResponse)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/accept");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("SendResponse", (object) SendResponse),

            }

            );

        }

        public async System.Threading.Tasks.Task declineAsync(System.String Comment, System.Nullable<System.Boolean> SendResponse)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/decline");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("SendResponse", (object) SendResponse),

            }

            );

        }

        public async System.Threading.Tasks.Task tentativelyAcceptAsync(System.String Comment, System.Nullable<System.Boolean> SendResponse)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/tentativelyAccept");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("SendResponse", (object) SendResponse),

            }

            );

        }

        public async System.Threading.Tasks.Task snoozeReminderAsync(global::Microsoft.Graph.DateTimeTimeZone NewReminderTime)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/snoozeReminder");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("NewReminderTime", (object) NewReminderTime),

            }

            );

        }

        public async System.Threading.Tasks.Task dismissReminderAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/dismissReminder");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IEvent> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IEventFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IEvent, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IEventFetcher)new global::Microsoft.Graph.EventFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IEvent> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Event, global::Microsoft.Graph.IEvent>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IEvent> _query;

    }

    internal partial class EventCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IEvent>, global::Microsoft.Graph.IEventCollection

    {

        internal EventCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IEventFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddeventAsync(global::Microsoft.Graph.IEvent item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IEventFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Event>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.EventFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class EventCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Conversation : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IConversation, global::Microsoft.Graph.IConversationFetcher

    {

        private global::Microsoft.Graph.ConversationThreadCollection _threadsCollection;

        private System.String _topic;

        private System.Boolean _hasAttachments;

        private System.DateTimeOffset _lastDeliveredDateTime;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _uniqueSenders;

        private System.String _preview;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ConversationThread> _threadsConcrete;

        public System.String Topic

        {

            get

            {

                return _topic;

            }

            set

            {

                if (value != _topic)

                {

                    _topic = value;

                    OnPropertyChanged("topic");

                }

            }

        }

        public System.Boolean HasAttachments

        {

            get

            {

                return _hasAttachments;

            }

            set

            {

                if (value != _hasAttachments)

                {

                    _hasAttachments = value;

                    OnPropertyChanged("hasAttachments");

                }

            }

        }

        public System.DateTimeOffset LastDeliveredDateTime

        {

            get

            {

                return _lastDeliveredDateTime;

            }

            set

            {

                if (value != _lastDeliveredDateTime)

                {

                    _lastDeliveredDateTime = value;

                    OnPropertyChanged("lastDeliveredDateTime");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> UniqueSenders

        {

            get

            {

                if (this._uniqueSenders == default(System.Collections.Generic.IList<System.String>))

                {

                    this._uniqueSenders = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._uniqueSenders.SetContainer(() => GetContainingEntity("uniqueSenders"));

                }

                return this._uniqueSenders;

            }

            set

            {

                UniqueSenders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        UniqueSenders.Add(i);

                    }

                }

            }

        }

        public System.String Preview

        {

            get

            {

                return _preview;

            }

            set

            {

                if (value != _preview)

                {

                    _preview = value;

                    OnPropertyChanged("preview");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IConversationThread> global::Microsoft.Graph.IConversation.Threads

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IConversationThread, global::Microsoft.Graph.ConversationThread>(Context, (DataServiceCollection<global::Microsoft.Graph.ConversationThread>)Threads);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Topic instead.")]

        public System.String topic

        {

            get

            {

                return Topic;

            }

            set

            {

                Topic = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HasAttachments instead.")]

        public System.Boolean hasAttachments

        {

            get

            {

                return HasAttachments;

            }

            set

            {

                HasAttachments = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LastDeliveredDateTime instead.")]

        public System.DateTimeOffset lastDeliveredDateTime

        {

            get

            {

                return LastDeliveredDateTime;

            }

            set

            {

                LastDeliveredDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UniqueSenders instead.")]

        public global::System.Collections.Generic.IList<System.String> uniqueSenders

        {

            get

            {

                return UniqueSenders;

            }

            set

            {

                UniqueSenders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Preview instead.")]

        public System.String preview

        {

            get

            {

                return Preview;

            }

            set

            {

                Preview = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Threads instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ConversationThread> threads

        {

            get

            {

                return Threads;

            }

            set

            {

                Threads = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ConversationThread> Threads

        {

            get

            {

                if (this._threadsConcrete == null)

                {

                    this._threadsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ConversationThread>();

                    this._threadsConcrete.SetContainer(() => GetContainingEntity("threads"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.ConversationThread>)this._threadsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Threads.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Threads.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IConversationThreadCollection global::Microsoft.Graph.IConversationFetcher.Threads

        {

            get

            {

                if (this._threadsCollection == null)

                {

                    this._threadsCollection = new global::Microsoft.Graph.ConversationThreadCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ConversationThread>(GetPath("threads")) : null,
                       Context,
                       this,
                       GetPath("threads"));

                }



                return this._threadsCollection;

            }

        }

        public Conversation() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversation> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Conversation, global::Microsoft.Graph.IConversation>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversation> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IConversation> global::Microsoft.Graph.IConversationFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IConversation>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IConversationFetcher global::Microsoft.Graph.IConversationFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IConversation, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IConversationFetcher)this;

        }

    }

    internal partial class ConversationFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IConversationFetcher

    {

        private global::Microsoft.Graph.ConversationThreadCollection _threadsCollection;

        public global::Microsoft.Graph.IConversationThreadCollection Threads

        {

            get

            {

                if (this._threadsCollection == null)

                {

                    this._threadsCollection = new global::Microsoft.Graph.ConversationThreadCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ConversationThread>(GetPath("threads")) : null,
                       Context,
                       this,
                       GetPath("threads"));

                }



                return this._threadsCollection;

            }

        }

        public ConversationFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IConversation> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IConversationFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IConversation, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IConversationFetcher)new global::Microsoft.Graph.ConversationFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversation> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Conversation, global::Microsoft.Graph.IConversation>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IConversation> _query;

    }

    internal partial class ConversationCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IConversation>, global::Microsoft.Graph.IConversationCollection

    {

        internal ConversationCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IConversationFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IConversation>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddconversationAsync(global::Microsoft.Graph.IConversation item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IConversationFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Conversation>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.ConversationFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class ConversationCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class ProfilePhoto : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IProfilePhoto, global::Microsoft.Graph.IProfilePhotoFetcher

    {

        private System.Nullable<System.Int32> _height;

        private System.Nullable<System.Int32> _width;

        private System.String _id;

        public System.Nullable<System.Int32> Height

        {

            get

            {

                return _height;

            }

            set

            {

                if (value != _height)

                {

                    _height = value;

                    OnPropertyChanged("height");

                }

            }

        }

        public System.Nullable<System.Int32> Width

        {

            get

            {

                return _width;

            }

            set

            {

                if (value != _width)

                {

                    _width = value;

                    OnPropertyChanged("width");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Height instead.")]

        public System.Nullable<System.Int32> height

        {

            get

            {

                return Height;

            }

            set

            {

                Height = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Width instead.")]

        public System.Nullable<System.Int32> width

        {

            get

            {

                return Width;

            }

            set

            {

                Width = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        public ProfilePhoto() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IProfilePhoto> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ProfilePhoto, global::Microsoft.Graph.IProfilePhoto>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IProfilePhoto> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IProfilePhoto> global::Microsoft.Graph.IProfilePhotoFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IProfilePhoto>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IProfilePhotoFetcher global::Microsoft.Graph.IProfilePhotoFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IProfilePhoto, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IProfilePhotoFetcher)this;

        }

    }

    internal partial class ProfilePhotoFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IProfilePhotoFetcher

    {

        public ProfilePhotoFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IProfilePhoto> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IProfilePhotoFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IProfilePhoto, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IProfilePhotoFetcher)new global::Microsoft.Graph.ProfilePhotoFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IProfilePhoto> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ProfilePhoto, global::Microsoft.Graph.IProfilePhoto>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IProfilePhoto> _query;

    }

    internal partial class ProfilePhotoCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IProfilePhoto>, global::Microsoft.Graph.IProfilePhotoCollection

    {

        internal ProfilePhotoCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IProfilePhotoFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IProfilePhoto>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddprofilePhotoAsync(global::Microsoft.Graph.IProfilePhoto item, System.IO.Stream stream, System.String contentType, System.Boolean deferSaveChanges = false, System.Boolean closeStream = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            Context.SetSaveStream(item, stream, closeStream, new DataServiceRequestArgs()

            {

                ContentType = contentType

            });

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IProfilePhotoFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.ProfilePhoto>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class ProfilePhotoCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Drive : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IDrive, global::Microsoft.Graph.IDriveFetcher

    {

        private global::Microsoft.Graph.DriveItem _root;

        private global::Microsoft.Graph.DriveItemFetcher _rootFetcher;

        private global::Microsoft.Graph.DriveItemCollection _itemsCollection;

        private global::Microsoft.Graph.DriveItemCollection _sharedCollection;

        private global::Microsoft.Graph.DriveItemCollection _specialCollection;

        private System.String _id;

        private System.String _driveType;

        private global::Microsoft.Graph.IdentitySet _owner;

        private global::Microsoft.Graph.Quota _quota;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem> _itemsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem> _sharedConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem> _specialConcrete;

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String DriveType

        {

            get

            {

                return _driveType;

            }

            set

            {

                if (value != _driveType)

                {

                    _driveType = value;

                    OnPropertyChanged("driveType");

                }

            }

        }

        public global::Microsoft.Graph.IdentitySet Owner

        {

            get

            {

                return _owner;

            }

            set

            {

                if (value != _owner)

                {

                    _owner = value;

                    OnPropertyChanged("owner");

                }

            }

        }

        public global::Microsoft.Graph.Quota Quota

        {

            get

            {

                return _quota;

            }

            set

            {

                if (value != _quota)

                {

                    _quota = value;

                    OnPropertyChanged("quota");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDriveItem> global::Microsoft.Graph.IDrive.Items

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDriveItem, global::Microsoft.Graph.DriveItem>(Context, (DataServiceCollection<global::Microsoft.Graph.DriveItem>)Items);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDriveItem> global::Microsoft.Graph.IDrive.Shared

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDriveItem, global::Microsoft.Graph.DriveItem>(Context, (DataServiceCollection<global::Microsoft.Graph.DriveItem>)Shared);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDriveItem> global::Microsoft.Graph.IDrive.Special

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDriveItem, global::Microsoft.Graph.DriveItem>(Context, (DataServiceCollection<global::Microsoft.Graph.DriveItem>)Special);

            }

        }

        global::Microsoft.Graph.IDriveItem global::Microsoft.Graph.IDrive.Root

        {

            get

            {

                return this._root;

            }

            set

            {

                if (this.Root != value)

                {

                    this.Root = (global::Microsoft.Graph.DriveItem)value;

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DriveType instead.")]

        public System.String driveType

        {

            get

            {

                return DriveType;

            }

            set

            {

                DriveType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Owner instead.")]

        public global::Microsoft.Graph.IdentitySet owner

        {

            get

            {

                return Owner;

            }

            set

            {

                Owner = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Quota instead.")]

        public global::Microsoft.Graph.Quota quota

        {

            get

            {

                return Quota;

            }

            set

            {

                Quota = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Items instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> items

        {

            get

            {

                return Items;

            }

            set

            {

                Items = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Shared instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> shared

        {

            get

            {

                return Shared;

            }

            set

            {

                Shared = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Special instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> special

        {

            get

            {

                return Special;

            }

            set

            {

                Special = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Root instead.")]

        public global::Microsoft.Graph.DriveItem root

        {

            get

            {

                return Root;

            }

            set

            {

                Root = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> Items

        {

            get

            {

                if (this._itemsConcrete == null)

                {

                    this._itemsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem>();

                    this._itemsConcrete.SetContainer(() => GetContainingEntity("items"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem>)this._itemsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Items.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Items.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> Shared

        {

            get

            {

                if (this._sharedConcrete == null)

                {

                    this._sharedConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem>();

                    this._sharedConcrete.SetContainer(() => GetContainingEntity("shared"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem>)this._sharedConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Shared.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Shared.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> Special

        {

            get

            {

                if (this._specialConcrete == null)

                {

                    this._specialConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem>();

                    this._specialConcrete.SetContainer(() => GetContainingEntity("special"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem>)this._specialConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Special.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Special.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.DriveItem Root

        {

            get

            {

                return this._root;

            }

            set

            {

                if (this._root != value)

                {

                    this._root = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "root", value);

                    }

                }

            }

        }

        global::Microsoft.Graph.IDriveItemCollection global::Microsoft.Graph.IDriveFetcher.Items

        {

            get

            {

                if (this._itemsCollection == null)

                {

                    this._itemsCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("items")) : null,
                       Context,
                       this,
                       GetPath("items"));

                }



                return this._itemsCollection;

            }

        }

        global::Microsoft.Graph.IDriveItemCollection global::Microsoft.Graph.IDriveFetcher.Shared

        {

            get

            {

                if (this._sharedCollection == null)

                {

                    this._sharedCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("shared")) : null,
                       Context,
                       this,
                       GetPath("shared"));

                }



                return this._sharedCollection;

            }

        }

        global::Microsoft.Graph.IDriveItemCollection global::Microsoft.Graph.IDriveFetcher.Special

        {

            get

            {

                if (this._specialCollection == null)

                {

                    this._specialCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("special")) : null,
                       Context,
                       this,
                       GetPath("special"));

                }



                return this._specialCollection;

            }

        }

        global::Microsoft.Graph.IDriveItemFetcher global::Microsoft.Graph.IDriveFetcher.Root

        {

            get

            {

                if (this._rootFetcher == null)

                {

                    this._rootFetcher = new global::Microsoft.Graph.DriveItemFetcher();

                    this._rootFetcher.Initialize(this.Context, GetPath("root"));

                }



                return this._rootFetcher;

            }

        }

        public Drive() : base()

        {

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<global::Microsoft.Graph.IDriveItem>> allPhotosAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/allPhotos");

            return (await this.Context.ExecuteAsync<global::Microsoft.Graph.DriveItem>(requestUri, "GET", false, new OperationParameter[]

            {

            }

            ));

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDrive> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Drive, global::Microsoft.Graph.IDrive>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDrive> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDrive> global::Microsoft.Graph.IDriveFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IDrive>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IDriveFetcher global::Microsoft.Graph.IDriveFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDrive, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDriveFetcher)this;

        }

    }

    internal partial class DriveFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IDriveFetcher

    {

        private global::Microsoft.Graph.DriveItemFetcher _rootFetcher;

        private global::Microsoft.Graph.DriveItemCollection _itemsCollection;

        private global::Microsoft.Graph.DriveItemCollection _sharedCollection;

        private global::Microsoft.Graph.DriveItemCollection _specialCollection;

        public global::Microsoft.Graph.IDriveItemCollection Items

        {

            get

            {

                if (this._itemsCollection == null)

                {

                    this._itemsCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("items")) : null,
                       Context,
                       this,
                       GetPath("items"));

                }



                return this._itemsCollection;

            }

        }

        public global::Microsoft.Graph.IDriveItemCollection Shared

        {

            get

            {

                if (this._sharedCollection == null)

                {

                    this._sharedCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("shared")) : null,
                       Context,
                       this,
                       GetPath("shared"));

                }



                return this._sharedCollection;

            }

        }

        public global::Microsoft.Graph.IDriveItemCollection Special

        {

            get

            {

                if (this._specialCollection == null)

                {

                    this._specialCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("special")) : null,
                       Context,
                       this,
                       GetPath("special"));

                }



                return this._specialCollection;

            }

        }

        public global::Microsoft.Graph.IDriveItemFetcher Root

        {

            get

            {

                if (this._rootFetcher == null)

                {

                    this._rootFetcher = new global::Microsoft.Graph.DriveItemFetcher();

                    this._rootFetcher.Initialize(this.Context, GetPath("root"));

                }



                return this._rootFetcher;

            }

        }

        public DriveFetcher() : base()

        {

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<global::Microsoft.Graph.IDriveItem>> allPhotosAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/allPhotos");

            return (await this.Context.ExecuteAsync<global::Microsoft.Graph.DriveItem>(requestUri, "GET", false, new OperationParameter[]

            {

            }

            ));

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IDrive> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IDriveFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IDrive, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IDriveFetcher)new global::Microsoft.Graph.DriveFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDrive> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Drive, global::Microsoft.Graph.IDrive>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IDrive> _query;

    }

    internal partial class DriveCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IDrive>, global::Microsoft.Graph.IDriveCollection

    {

        internal DriveCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IDriveFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDrive>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AdddriveAsync(global::Microsoft.Graph.IDrive item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IDriveFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Drive>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.DriveFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class DriveCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Notes : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.INotes, global::Microsoft.Graph.INotesFetcher

    {

        private global::Microsoft.Graph.NotebookCollection _notebooksCollection;

        private global::Microsoft.Graph.SectionCollection _sectionsCollection;

        private global::Microsoft.Graph.SectionGroupCollection _sectionGroupsCollection;

        private global::Microsoft.Graph.PageCollection _pagesCollection;

        private global::Microsoft.Graph.ResourceCollection _resourcesCollection;

        private global::Microsoft.Graph.NotesOperationCollection _operationsCollection;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Notebook> _notebooksConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Section> _sectionsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.SectionGroup> _sectionGroupsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Page> _pagesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Resource> _resourcesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.NotesOperation> _operationsConcrete;

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.INotebook> global::Microsoft.Graph.INotes.Notebooks

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.INotebook, global::Microsoft.Graph.Notebook>(Context, (DataServiceCollection<global::Microsoft.Graph.Notebook>)Notebooks);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ISection> global::Microsoft.Graph.INotes.Sections

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ISection, global::Microsoft.Graph.Section>(Context, (DataServiceCollection<global::Microsoft.Graph.Section>)Sections);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ISectionGroup> global::Microsoft.Graph.INotes.SectionGroups

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ISectionGroup, global::Microsoft.Graph.SectionGroup>(Context, (DataServiceCollection<global::Microsoft.Graph.SectionGroup>)SectionGroups);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPage> global::Microsoft.Graph.INotes.Pages

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IPage, global::Microsoft.Graph.Page>(Context, (DataServiceCollection<global::Microsoft.Graph.Page>)Pages);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IResource> global::Microsoft.Graph.INotes.Resources

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IResource, global::Microsoft.Graph.Resource>(Context, (DataServiceCollection<global::Microsoft.Graph.Resource>)Resources);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.INotesOperation> global::Microsoft.Graph.INotes.Operations

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.INotesOperation, global::Microsoft.Graph.NotesOperation>(Context, (DataServiceCollection<global::Microsoft.Graph.NotesOperation>)Operations);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Notebooks instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Notebook> notebooks

        {

            get

            {

                return Notebooks;

            }

            set

            {

                Notebooks = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Sections instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Section> sections

        {

            get

            {

                return Sections;

            }

            set

            {

                Sections = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SectionGroups instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.SectionGroup> sectionGroups

        {

            get

            {

                return SectionGroups;

            }

            set

            {

                SectionGroups = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Pages instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Page> pages

        {

            get

            {

                return Pages;

            }

            set

            {

                Pages = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Resources instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Resource> resources

        {

            get

            {

                return Resources;

            }

            set

            {

                Resources = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Operations instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.NotesOperation> operations

        {

            get

            {

                return Operations;

            }

            set

            {

                Operations = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Notebook> Notebooks

        {

            get

            {

                if (this._notebooksConcrete == null)

                {

                    this._notebooksConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Notebook>();

                    this._notebooksConcrete.SetContainer(() => GetContainingEntity("notebooks"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Notebook>)this._notebooksConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Notebooks.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Notebooks.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Section> Sections

        {

            get

            {

                if (this._sectionsConcrete == null)

                {

                    this._sectionsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Section>();

                    this._sectionsConcrete.SetContainer(() => GetContainingEntity("sections"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Section>)this._sectionsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Sections.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Sections.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.SectionGroup> SectionGroups

        {

            get

            {

                if (this._sectionGroupsConcrete == null)

                {

                    this._sectionGroupsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.SectionGroup>();

                    this._sectionGroupsConcrete.SetContainer(() => GetContainingEntity("sectionGroups"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.SectionGroup>)this._sectionGroupsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                SectionGroups.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        SectionGroups.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Page> Pages

        {

            get

            {

                if (this._pagesConcrete == null)

                {

                    this._pagesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Page>();

                    this._pagesConcrete.SetContainer(() => GetContainingEntity("pages"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Page>)this._pagesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Pages.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Pages.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Resource> Resources

        {

            get

            {

                if (this._resourcesConcrete == null)

                {

                    this._resourcesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Resource>();

                    this._resourcesConcrete.SetContainer(() => GetContainingEntity("resources"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Resource>)this._resourcesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Resources.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Resources.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.NotesOperation> Operations

        {

            get

            {

                if (this._operationsConcrete == null)

                {

                    this._operationsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.NotesOperation>();

                    this._operationsConcrete.SetContainer(() => GetContainingEntity("operations"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.NotesOperation>)this._operationsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Operations.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Operations.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.INotebookCollection global::Microsoft.Graph.INotesFetcher.Notebooks

        {

            get

            {

                if (this._notebooksCollection == null)

                {

                    this._notebooksCollection = new global::Microsoft.Graph.NotebookCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Notebook>(GetPath("notebooks")) : null,
                       Context,
                       this,
                       GetPath("notebooks"));

                }



                return this._notebooksCollection;

            }

        }

        global::Microsoft.Graph.ISectionCollection global::Microsoft.Graph.INotesFetcher.Sections

        {

            get

            {

                if (this._sectionsCollection == null)

                {

                    this._sectionsCollection = new global::Microsoft.Graph.SectionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Section>(GetPath("sections")) : null,
                       Context,
                       this,
                       GetPath("sections"));

                }



                return this._sectionsCollection;

            }

        }

        global::Microsoft.Graph.ISectionGroupCollection global::Microsoft.Graph.INotesFetcher.SectionGroups

        {

            get

            {

                if (this._sectionGroupsCollection == null)

                {

                    this._sectionGroupsCollection = new global::Microsoft.Graph.SectionGroupCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.SectionGroup>(GetPath("sectionGroups")) : null,
                       Context,
                       this,
                       GetPath("sectionGroups"));

                }



                return this._sectionGroupsCollection;

            }

        }

        global::Microsoft.Graph.IPageCollection global::Microsoft.Graph.INotesFetcher.Pages

        {

            get

            {

                if (this._pagesCollection == null)

                {

                    this._pagesCollection = new global::Microsoft.Graph.PageCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Page>(GetPath("pages")) : null,
                       Context,
                       this,
                       GetPath("pages"));

                }



                return this._pagesCollection;

            }

        }

        global::Microsoft.Graph.IResourceCollection global::Microsoft.Graph.INotesFetcher.Resources

        {

            get

            {

                if (this._resourcesCollection == null)

                {

                    this._resourcesCollection = new global::Microsoft.Graph.ResourceCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Resource>(GetPath("resources")) : null,
                       Context,
                       this,
                       GetPath("resources"));

                }



                return this._resourcesCollection;

            }

        }

        global::Microsoft.Graph.INotesOperationCollection global::Microsoft.Graph.INotesFetcher.Operations

        {

            get

            {

                if (this._operationsCollection == null)

                {

                    this._operationsCollection = new global::Microsoft.Graph.NotesOperationCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.NotesOperation>(GetPath("operations")) : null,
                       Context,
                       this,
                       GetPath("operations"));

                }



                return this._operationsCollection;

            }

        }

        public Notes() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.INotes> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Notes, global::Microsoft.Graph.INotes>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.INotes> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.INotes> global::Microsoft.Graph.INotesFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.INotes>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.INotesFetcher global::Microsoft.Graph.INotesFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.INotes, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.INotesFetcher)this;

        }

    }

    internal partial class NotesFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.INotesFetcher

    {

        private global::Microsoft.Graph.NotebookCollection _notebooksCollection;

        private global::Microsoft.Graph.SectionCollection _sectionsCollection;

        private global::Microsoft.Graph.SectionGroupCollection _sectionGroupsCollection;

        private global::Microsoft.Graph.PageCollection _pagesCollection;

        private global::Microsoft.Graph.ResourceCollection _resourcesCollection;

        private global::Microsoft.Graph.NotesOperationCollection _operationsCollection;

        public global::Microsoft.Graph.INotebookCollection Notebooks

        {

            get

            {

                if (this._notebooksCollection == null)

                {

                    this._notebooksCollection = new global::Microsoft.Graph.NotebookCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Notebook>(GetPath("notebooks")) : null,
                       Context,
                       this,
                       GetPath("notebooks"));

                }



                return this._notebooksCollection;

            }

        }

        public global::Microsoft.Graph.ISectionCollection Sections

        {

            get

            {

                if (this._sectionsCollection == null)

                {

                    this._sectionsCollection = new global::Microsoft.Graph.SectionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Section>(GetPath("sections")) : null,
                       Context,
                       this,
                       GetPath("sections"));

                }



                return this._sectionsCollection;

            }

        }

        public global::Microsoft.Graph.ISectionGroupCollection SectionGroups

        {

            get

            {

                if (this._sectionGroupsCollection == null)

                {

                    this._sectionGroupsCollection = new global::Microsoft.Graph.SectionGroupCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.SectionGroup>(GetPath("sectionGroups")) : null,
                       Context,
                       this,
                       GetPath("sectionGroups"));

                }



                return this._sectionGroupsCollection;

            }

        }

        public global::Microsoft.Graph.IPageCollection Pages

        {

            get

            {

                if (this._pagesCollection == null)

                {

                    this._pagesCollection = new global::Microsoft.Graph.PageCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Page>(GetPath("pages")) : null,
                       Context,
                       this,
                       GetPath("pages"));

                }



                return this._pagesCollection;

            }

        }

        public global::Microsoft.Graph.IResourceCollection Resources

        {

            get

            {

                if (this._resourcesCollection == null)

                {

                    this._resourcesCollection = new global::Microsoft.Graph.ResourceCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Resource>(GetPath("resources")) : null,
                       Context,
                       this,
                       GetPath("resources"));

                }



                return this._resourcesCollection;

            }

        }

        public global::Microsoft.Graph.INotesOperationCollection Operations

        {

            get

            {

                if (this._operationsCollection == null)

                {

                    this._operationsCollection = new global::Microsoft.Graph.NotesOperationCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.NotesOperation>(GetPath("operations")) : null,
                       Context,
                       this,
                       GetPath("operations"));

                }



                return this._operationsCollection;

            }

        }

        public NotesFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.INotes> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.INotesFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.INotes, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.INotesFetcher)new global::Microsoft.Graph.NotesFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.INotes> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Notes, global::Microsoft.Graph.INotes>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.INotes> _query;

    }

    internal partial class NotesCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.INotes>, global::Microsoft.Graph.INotesCollection

    {

        internal NotesCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.INotesFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.INotes>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddnotesAsync(global::Microsoft.Graph.INotes item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.INotesFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Notes>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.NotesFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class NotesCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Plan : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IPlan, global::Microsoft.Graph.IPlanFetcher

    {

        private global::Microsoft.Graph.PlanDetails _details;

        private global::Microsoft.Graph.PlanTaskBoard _assignedToTaskBoard;

        private global::Microsoft.Graph.PlanTaskBoard _progressTaskBoard;

        private global::Microsoft.Graph.PlanTaskBoard _bucketTaskBoard;

        private global::Microsoft.Graph.PlanDetailsFetcher _detailsFetcher;

        private global::Microsoft.Graph.PlanTaskBoardFetcher _assignedToTaskBoardFetcher;

        private global::Microsoft.Graph.PlanTaskBoardFetcher _progressTaskBoardFetcher;

        private global::Microsoft.Graph.PlanTaskBoardFetcher _bucketTaskBoardFetcher;

        private global::Microsoft.Graph.TaskCollection _tasksCollection;

        private global::Microsoft.Graph.BucketCollection _bucketsCollection;

        private System.String _createdBy;

        private System.String _owner;

        private System.String _title;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Task> _tasksConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Bucket> _bucketsConcrete;

        public System.String CreatedBy

        {

            get

            {

                return _createdBy;

            }

            set

            {

                if (value != _createdBy)

                {

                    _createdBy = value;

                    OnPropertyChanged("createdBy");

                }

            }

        }

        public System.String Owner

        {

            get

            {

                return _owner;

            }

            set

            {

                if (value != _owner)

                {

                    _owner = value;

                    OnPropertyChanged("owner");

                }

            }

        }

        public System.String Title

        {

            get

            {

                return _title;

            }

            set

            {

                if (value != _title)

                {

                    _title = value;

                    OnPropertyChanged("title");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ITask> global::Microsoft.Graph.IPlan.Tasks

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ITask, global::Microsoft.Graph.Task>(Context, (DataServiceCollection<global::Microsoft.Graph.Task>)Tasks);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IBucket> global::Microsoft.Graph.IPlan.Buckets

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IBucket, global::Microsoft.Graph.Bucket>(Context, (DataServiceCollection<global::Microsoft.Graph.Bucket>)Buckets);

            }

        }

        global::Microsoft.Graph.IPlanDetails global::Microsoft.Graph.IPlan.Details

        {

            get

            {

                return this._details;

            }

            set

            {

                if (this.Details != value)

                {

                    this.Details = (global::Microsoft.Graph.PlanDetails)value;

                }

            }

        }

        global::Microsoft.Graph.IPlanTaskBoard global::Microsoft.Graph.IPlan.AssignedToTaskBoard

        {

            get

            {

                return this._assignedToTaskBoard;

            }

            set

            {

                if (this.AssignedToTaskBoard != value)

                {

                    this.AssignedToTaskBoard = (global::Microsoft.Graph.PlanTaskBoard)value;

                }

            }

        }

        global::Microsoft.Graph.IPlanTaskBoard global::Microsoft.Graph.IPlan.ProgressTaskBoard

        {

            get

            {

                return this._progressTaskBoard;

            }

            set

            {

                if (this.ProgressTaskBoard != value)

                {

                    this.ProgressTaskBoard = (global::Microsoft.Graph.PlanTaskBoard)value;

                }

            }

        }

        global::Microsoft.Graph.IPlanTaskBoard global::Microsoft.Graph.IPlan.BucketTaskBoard

        {

            get

            {

                return this._bucketTaskBoard;

            }

            set

            {

                if (this.BucketTaskBoard != value)

                {

                    this.BucketTaskBoard = (global::Microsoft.Graph.PlanTaskBoard)value;

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedBy instead.")]

        public System.String createdBy

        {

            get

            {

                return CreatedBy;

            }

            set

            {

                CreatedBy = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Owner instead.")]

        public System.String owner

        {

            get

            {

                return Owner;

            }

            set

            {

                Owner = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Title instead.")]

        public System.String title

        {

            get

            {

                return Title;

            }

            set

            {

                Title = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Tasks instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Task> tasks

        {

            get

            {

                return Tasks;

            }

            set

            {

                Tasks = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Buckets instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Bucket> buckets

        {

            get

            {

                return Buckets;

            }

            set

            {

                Buckets = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Details instead.")]

        public global::Microsoft.Graph.PlanDetails details

        {

            get

            {

                return Details;

            }

            set

            {

                Details = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AssignedToTaskBoard instead.")]

        public global::Microsoft.Graph.PlanTaskBoard assignedToTaskBoard

        {

            get

            {

                return AssignedToTaskBoard;

            }

            set

            {

                AssignedToTaskBoard = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProgressTaskBoard instead.")]

        public global::Microsoft.Graph.PlanTaskBoard progressTaskBoard

        {

            get

            {

                return ProgressTaskBoard;

            }

            set

            {

                ProgressTaskBoard = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BucketTaskBoard instead.")]

        public global::Microsoft.Graph.PlanTaskBoard bucketTaskBoard

        {

            get

            {

                return BucketTaskBoard;

            }

            set

            {

                BucketTaskBoard = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Task> Tasks

        {

            get

            {

                if (this._tasksConcrete == null)

                {

                    this._tasksConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Task>();

                    this._tasksConcrete.SetContainer(() => GetContainingEntity("tasks"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Task>)this._tasksConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Tasks.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Tasks.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Bucket> Buckets

        {

            get

            {

                if (this._bucketsConcrete == null)

                {

                    this._bucketsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Bucket>();

                    this._bucketsConcrete.SetContainer(() => GetContainingEntity("buckets"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Bucket>)this._bucketsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Buckets.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Buckets.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.PlanDetails Details

        {

            get

            {

                return this._details;

            }

            set

            {

                if (this._details != value)

                {

                    this._details = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "details", value);

                    }

                }

            }

        }

        public global::Microsoft.Graph.PlanTaskBoard AssignedToTaskBoard

        {

            get

            {

                return this._assignedToTaskBoard;

            }

            set

            {

                if (this._assignedToTaskBoard != value)

                {

                    this._assignedToTaskBoard = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "assignedToTaskBoard", value);

                    }

                }

            }

        }

        public global::Microsoft.Graph.PlanTaskBoard ProgressTaskBoard

        {

            get

            {

                return this._progressTaskBoard;

            }

            set

            {

                if (this._progressTaskBoard != value)

                {

                    this._progressTaskBoard = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "progressTaskBoard", value);

                    }

                }

            }

        }

        public global::Microsoft.Graph.PlanTaskBoard BucketTaskBoard

        {

            get

            {

                return this._bucketTaskBoard;

            }

            set

            {

                if (this._bucketTaskBoard != value)

                {

                    this._bucketTaskBoard = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "bucketTaskBoard", value);

                    }

                }

            }

        }

        global::Microsoft.Graph.ITaskCollection global::Microsoft.Graph.IPlanFetcher.Tasks

        {

            get

            {

                if (this._tasksCollection == null)

                {

                    this._tasksCollection = new global::Microsoft.Graph.TaskCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Task>(GetPath("tasks")) : null,
                       Context,
                       this,
                       GetPath("tasks"));

                }



                return this._tasksCollection;

            }

        }

        global::Microsoft.Graph.IBucketCollection global::Microsoft.Graph.IPlanFetcher.Buckets

        {

            get

            {

                if (this._bucketsCollection == null)

                {

                    this._bucketsCollection = new global::Microsoft.Graph.BucketCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Bucket>(GetPath("buckets")) : null,
                       Context,
                       this,
                       GetPath("buckets"));

                }



                return this._bucketsCollection;

            }

        }

        global::Microsoft.Graph.IPlanDetailsFetcher global::Microsoft.Graph.IPlanFetcher.Details

        {

            get

            {

                if (this._detailsFetcher == null)

                {

                    this._detailsFetcher = new global::Microsoft.Graph.PlanDetailsFetcher();

                    this._detailsFetcher.Initialize(this.Context, GetPath("details"));

                }



                return this._detailsFetcher;

            }

        }

        global::Microsoft.Graph.IPlanTaskBoardFetcher global::Microsoft.Graph.IPlanFetcher.AssignedToTaskBoard

        {

            get

            {

                if (this._assignedToTaskBoardFetcher == null)

                {

                    this._assignedToTaskBoardFetcher = new global::Microsoft.Graph.PlanTaskBoardFetcher();

                    this._assignedToTaskBoardFetcher.Initialize(this.Context, GetPath("assignedToTaskBoard"));

                }



                return this._assignedToTaskBoardFetcher;

            }

        }

        global::Microsoft.Graph.IPlanTaskBoardFetcher global::Microsoft.Graph.IPlanFetcher.ProgressTaskBoard

        {

            get

            {

                if (this._progressTaskBoardFetcher == null)

                {

                    this._progressTaskBoardFetcher = new global::Microsoft.Graph.PlanTaskBoardFetcher();

                    this._progressTaskBoardFetcher.Initialize(this.Context, GetPath("progressTaskBoard"));

                }



                return this._progressTaskBoardFetcher;

            }

        }

        global::Microsoft.Graph.IPlanTaskBoardFetcher global::Microsoft.Graph.IPlanFetcher.BucketTaskBoard

        {

            get

            {

                if (this._bucketTaskBoardFetcher == null)

                {

                    this._bucketTaskBoardFetcher = new global::Microsoft.Graph.PlanTaskBoardFetcher();

                    this._bucketTaskBoardFetcher.Initialize(this.Context, GetPath("bucketTaskBoard"));

                }



                return this._bucketTaskBoardFetcher;

            }

        }

        public Plan() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPlan> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Plan, global::Microsoft.Graph.IPlan>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPlan> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IPlan> global::Microsoft.Graph.IPlanFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IPlan>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IPlanFetcher global::Microsoft.Graph.IPlanFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IPlan, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IPlanFetcher)this;

        }

    }

    internal partial class PlanFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IPlanFetcher

    {

        private global::Microsoft.Graph.PlanDetailsFetcher _detailsFetcher;

        private global::Microsoft.Graph.PlanTaskBoardFetcher _assignedToTaskBoardFetcher;

        private global::Microsoft.Graph.PlanTaskBoardFetcher _progressTaskBoardFetcher;

        private global::Microsoft.Graph.PlanTaskBoardFetcher _bucketTaskBoardFetcher;

        private global::Microsoft.Graph.TaskCollection _tasksCollection;

        private global::Microsoft.Graph.BucketCollection _bucketsCollection;

        public global::Microsoft.Graph.ITaskCollection Tasks

        {

            get

            {

                if (this._tasksCollection == null)

                {

                    this._tasksCollection = new global::Microsoft.Graph.TaskCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Task>(GetPath("tasks")) : null,
                       Context,
                       this,
                       GetPath("tasks"));

                }



                return this._tasksCollection;

            }

        }

        public global::Microsoft.Graph.IBucketCollection Buckets

        {

            get

            {

                if (this._bucketsCollection == null)

                {

                    this._bucketsCollection = new global::Microsoft.Graph.BucketCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Bucket>(GetPath("buckets")) : null,
                       Context,
                       this,
                       GetPath("buckets"));

                }



                return this._bucketsCollection;

            }

        }

        public global::Microsoft.Graph.IPlanDetailsFetcher Details

        {

            get

            {

                if (this._detailsFetcher == null)

                {

                    this._detailsFetcher = new global::Microsoft.Graph.PlanDetailsFetcher();

                    this._detailsFetcher.Initialize(this.Context, GetPath("details"));

                }



                return this._detailsFetcher;

            }

        }

        public global::Microsoft.Graph.IPlanTaskBoardFetcher AssignedToTaskBoard

        {

            get

            {

                if (this._assignedToTaskBoardFetcher == null)

                {

                    this._assignedToTaskBoardFetcher = new global::Microsoft.Graph.PlanTaskBoardFetcher();

                    this._assignedToTaskBoardFetcher.Initialize(this.Context, GetPath("assignedToTaskBoard"));

                }



                return this._assignedToTaskBoardFetcher;

            }

        }

        public global::Microsoft.Graph.IPlanTaskBoardFetcher ProgressTaskBoard

        {

            get

            {

                if (this._progressTaskBoardFetcher == null)

                {

                    this._progressTaskBoardFetcher = new global::Microsoft.Graph.PlanTaskBoardFetcher();

                    this._progressTaskBoardFetcher.Initialize(this.Context, GetPath("progressTaskBoard"));

                }



                return this._progressTaskBoardFetcher;

            }

        }

        public global::Microsoft.Graph.IPlanTaskBoardFetcher BucketTaskBoard

        {

            get

            {

                if (this._bucketTaskBoardFetcher == null)

                {

                    this._bucketTaskBoardFetcher = new global::Microsoft.Graph.PlanTaskBoardFetcher();

                    this._bucketTaskBoardFetcher.Initialize(this.Context, GetPath("bucketTaskBoard"));

                }



                return this._bucketTaskBoardFetcher;

            }

        }

        public PlanFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IPlan> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IPlanFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IPlan, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IPlanFetcher)new global::Microsoft.Graph.PlanFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPlan> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Plan, global::Microsoft.Graph.IPlan>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPlan> _query;

    }

    internal partial class PlanCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IPlan>, global::Microsoft.Graph.IPlanCollection

    {

        internal PlanCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IPlanFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPlan>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddplanAsync(global::Microsoft.Graph.IPlan item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IPlanFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Plan>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.PlanFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class PlanCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class OAuth2PermissionGrant : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IOAuth2PermissionGrant, global::Microsoft.Graph.IOAuth2PermissionGrantFetcher

    {

        private System.String _clientId;

        private System.String _consentType;

        private System.Nullable<System.DateTimeOffset> _expiryTime;

        private System.String _id;

        private System.String _principalId;

        private System.String _resourceId;

        private System.String _scope;

        private System.Nullable<System.DateTimeOffset> _startTime;

        public System.String ClientId

        {

            get

            {

                return _clientId;

            }

            set

            {

                if (value != _clientId)

                {

                    _clientId = value;

                    OnPropertyChanged("clientId");

                }

            }

        }

        public System.String ConsentType

        {

            get

            {

                return _consentType;

            }

            set

            {

                if (value != _consentType)

                {

                    _consentType = value;

                    OnPropertyChanged("consentType");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> ExpiryTime

        {

            get

            {

                return _expiryTime;

            }

            set

            {

                if (value != _expiryTime)

                {

                    _expiryTime = value;

                    OnPropertyChanged("expiryTime");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public System.String PrincipalId

        {

            get

            {

                return _principalId;

            }

            set

            {

                if (value != _principalId)

                {

                    _principalId = value;

                    OnPropertyChanged("principalId");

                }

            }

        }

        public System.String ResourceId

        {

            get

            {

                return _resourceId;

            }

            set

            {

                if (value != _resourceId)

                {

                    _resourceId = value;

                    OnPropertyChanged("resourceId");

                }

            }

        }

        public System.String Scope

        {

            get

            {

                return _scope;

            }

            set

            {

                if (value != _scope)

                {

                    _scope = value;

                    OnPropertyChanged("scope");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> StartTime

        {

            get

            {

                return _startTime;

            }

            set

            {

                if (value != _startTime)

                {

                    _startTime = value;

                    OnPropertyChanged("startTime");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ClientId instead.")]

        public System.String clientId

        {

            get

            {

                return ClientId;

            }

            set

            {

                ClientId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ConsentType instead.")]

        public System.String consentType

        {

            get

            {

                return ConsentType;

            }

            set

            {

                ConsentType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ExpiryTime instead.")]

        public System.Nullable<System.DateTimeOffset> expiryTime

        {

            get

            {

                return ExpiryTime;

            }

            set

            {

                ExpiryTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PrincipalId instead.")]

        public System.String principalId

        {

            get

            {

                return PrincipalId;

            }

            set

            {

                PrincipalId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ResourceId instead.")]

        public System.String resourceId

        {

            get

            {

                return ResourceId;

            }

            set

            {

                ResourceId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Scope instead.")]

        public System.String scope

        {

            get

            {

                return Scope;

            }

            set

            {

                Scope = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use StartTime instead.")]

        public System.Nullable<System.DateTimeOffset> startTime

        {

            get

            {

                return StartTime;

            }

            set

            {

                StartTime = value;

            }

        }

        public OAuth2PermissionGrant() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOAuth2PermissionGrant> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.OAuth2PermissionGrant, global::Microsoft.Graph.IOAuth2PermissionGrant>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOAuth2PermissionGrant> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IOAuth2PermissionGrant> global::Microsoft.Graph.IOAuth2PermissionGrantFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IOAuth2PermissionGrant>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IOAuth2PermissionGrantFetcher global::Microsoft.Graph.IOAuth2PermissionGrantFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IOAuth2PermissionGrant, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IOAuth2PermissionGrantFetcher)this;

        }

    }

    internal partial class OAuth2PermissionGrantFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IOAuth2PermissionGrantFetcher

    {

        public OAuth2PermissionGrantFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IOAuth2PermissionGrant> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IOAuth2PermissionGrantFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IOAuth2PermissionGrant, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IOAuth2PermissionGrantFetcher)new global::Microsoft.Graph.OAuth2PermissionGrantFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOAuth2PermissionGrant> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.OAuth2PermissionGrant, global::Microsoft.Graph.IOAuth2PermissionGrant>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOAuth2PermissionGrant> _query;

    }

    internal partial class OAuth2PermissionGrantCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IOAuth2PermissionGrant>, global::Microsoft.Graph.IOAuth2PermissionGrantCollection

    {

        internal OAuth2PermissionGrantCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IOAuth2PermissionGrantFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IOAuth2PermissionGrant>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddoAuth2PermissionGrantAsync(global::Microsoft.Graph.IOAuth2PermissionGrant item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IOAuth2PermissionGrantFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.OAuth2PermissionGrant>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.OAuth2PermissionGrantFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class OAuth2PermissionGrantCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class ServicePrincipal : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IServicePrincipal, global::Microsoft.Graph.IServicePrincipalFetcher

    {

        private global::Microsoft.Graph.AppRoleAssignmentCollection _appRoleAssignedToCollection;

        private global::Microsoft.Graph.AppRoleAssignmentCollection _appRoleAssignmentsCollection;

        private global::Microsoft.Graph.OAuth2PermissionGrantCollection _oauth2PermissionGrantsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _createdObjectsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownedObjectsCollection;

        private System.Nullable<System.Boolean> _accountEnabled;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AddIn> _addIns;

        private System.String _appDisplayName;

        private System.String _appId;

        private System.Nullable<System.Guid> _appOwnerOrganizationId;

        private System.Boolean _appRoleAssignmentRequired;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AppRole> _appRoles;

        private System.String _displayName;

        private System.String _errorUrl;

        private System.String _homepage;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.KeyCredential> _keyCredentials;

        private System.String _logoutUrl;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.OAuth2Permission> _oauth2Permissions;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.PasswordCredential> _passwordCredentials;

        private System.String _preferredTokenSigningKeyThumbprint;

        private System.String _publisherName;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _replyUrls;

        private System.String _samlMetadataUrl;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _servicePrincipalNames;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _tags;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.AppRoleAssignment> _appRoleAssignedToConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.AppRoleAssignment> _appRoleAssignmentsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.OAuth2PermissionGrant> _oauth2PermissionGrantsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _memberOfConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _createdObjectsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _ownersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _ownedObjectsConcrete;

        public System.Nullable<System.Boolean> AccountEnabled

        {

            get

            {

                return _accountEnabled;

            }

            set

            {

                if (value != _accountEnabled)

                {

                    _accountEnabled = value;

                    OnPropertyChanged("accountEnabled");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AddIn> AddIns

        {

            get

            {

                if (this._addIns == default(System.Collections.Generic.IList<global::Microsoft.Graph.AddIn>))

                {

                    this._addIns = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AddIn>();

                    this._addIns.SetContainer(() => GetContainingEntity("addIns"));

                }

                return this._addIns;

            }

            set

            {

                AddIns.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AddIns.Add(i);

                    }

                }

            }

        }

        public System.String AppDisplayName

        {

            get

            {

                return _appDisplayName;

            }

            set

            {

                if (value != _appDisplayName)

                {

                    _appDisplayName = value;

                    OnPropertyChanged("appDisplayName");

                }

            }

        }

        public System.String AppId

        {

            get

            {

                return _appId;

            }

            set

            {

                if (value != _appId)

                {

                    _appId = value;

                    OnPropertyChanged("appId");

                }

            }

        }

        public System.Nullable<System.Guid> AppOwnerOrganizationId

        {

            get

            {

                return _appOwnerOrganizationId;

            }

            set

            {

                if (value != _appOwnerOrganizationId)

                {

                    _appOwnerOrganizationId = value;

                    OnPropertyChanged("appOwnerOrganizationId");

                }

            }

        }

        public System.Boolean AppRoleAssignmentRequired

        {

            get

            {

                return _appRoleAssignmentRequired;

            }

            set

            {

                if (value != _appRoleAssignmentRequired)

                {

                    _appRoleAssignmentRequired = value;

                    OnPropertyChanged("appRoleAssignmentRequired");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AppRole> AppRoles

        {

            get

            {

                if (this._appRoles == default(System.Collections.Generic.IList<global::Microsoft.Graph.AppRole>))

                {

                    this._appRoles = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AppRole>();

                    this._appRoles.SetContainer(() => GetContainingEntity("appRoles"));

                }

                return this._appRoles;

            }

            set

            {

                AppRoles.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AppRoles.Add(i);

                    }

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String ErrorUrl

        {

            get

            {

                return _errorUrl;

            }

            set

            {

                if (value != _errorUrl)

                {

                    _errorUrl = value;

                    OnPropertyChanged("errorUrl");

                }

            }

        }

        public System.String Homepage

        {

            get

            {

                return _homepage;

            }

            set

            {

                if (value != _homepage)

                {

                    _homepage = value;

                    OnPropertyChanged("homepage");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.KeyCredential> KeyCredentials

        {

            get

            {

                if (this._keyCredentials == default(System.Collections.Generic.IList<global::Microsoft.Graph.KeyCredential>))

                {

                    this._keyCredentials = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.KeyCredential>();

                    this._keyCredentials.SetContainer(() => GetContainingEntity("keyCredentials"));

                }

                return this._keyCredentials;

            }

            set

            {

                KeyCredentials.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        KeyCredentials.Add(i);

                    }

                }

            }

        }

        public System.String LogoutUrl

        {

            get

            {

                return _logoutUrl;

            }

            set

            {

                if (value != _logoutUrl)

                {

                    _logoutUrl = value;

                    OnPropertyChanged("logoutUrl");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2Permission> Oauth2Permissions

        {

            get

            {

                if (this._oauth2Permissions == default(System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2Permission>))

                {

                    this._oauth2Permissions = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.OAuth2Permission>();

                    this._oauth2Permissions.SetContainer(() => GetContainingEntity("oauth2Permissions"));

                }

                return this._oauth2Permissions;

            }

            set

            {

                Oauth2Permissions.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Oauth2Permissions.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.PasswordCredential> PasswordCredentials

        {

            get

            {

                if (this._passwordCredentials == default(System.Collections.Generic.IList<global::Microsoft.Graph.PasswordCredential>))

                {

                    this._passwordCredentials = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.PasswordCredential>();

                    this._passwordCredentials.SetContainer(() => GetContainingEntity("passwordCredentials"));

                }

                return this._passwordCredentials;

            }

            set

            {

                PasswordCredentials.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        PasswordCredentials.Add(i);

                    }

                }

            }

        }

        public System.String PreferredTokenSigningKeyThumbprint

        {

            get

            {

                return _preferredTokenSigningKeyThumbprint;

            }

            set

            {

                if (value != _preferredTokenSigningKeyThumbprint)

                {

                    _preferredTokenSigningKeyThumbprint = value;

                    OnPropertyChanged("preferredTokenSigningKeyThumbprint");

                }

            }

        }

        public System.String PublisherName

        {

            get

            {

                return _publisherName;

            }

            set

            {

                if (value != _publisherName)

                {

                    _publisherName = value;

                    OnPropertyChanged("publisherName");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ReplyUrls

        {

            get

            {

                if (this._replyUrls == default(System.Collections.Generic.IList<System.String>))

                {

                    this._replyUrls = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._replyUrls.SetContainer(() => GetContainingEntity("replyUrls"));

                }

                return this._replyUrls;

            }

            set

            {

                ReplyUrls.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ReplyUrls.Add(i);

                    }

                }

            }

        }

        public System.String SamlMetadataUrl

        {

            get

            {

                return _samlMetadataUrl;

            }

            set

            {

                if (value != _samlMetadataUrl)

                {

                    _samlMetadataUrl = value;

                    OnPropertyChanged("samlMetadataUrl");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ServicePrincipalNames

        {

            get

            {

                if (this._servicePrincipalNames == default(System.Collections.Generic.IList<System.String>))

                {

                    this._servicePrincipalNames = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._servicePrincipalNames.SetContainer(() => GetContainingEntity("servicePrincipalNames"));

                }

                return this._servicePrincipalNames;

            }

            set

            {

                ServicePrincipalNames.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ServicePrincipalNames.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Tags

        {

            get

            {

                if (this._tags == default(System.Collections.Generic.IList<System.String>))

                {

                    this._tags = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._tags.SetContainer(() => GetContainingEntity("tags"));

                }

                return this._tags;

            }

            set

            {

                Tags.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Tags.Add(i);

                    }

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IAppRoleAssignment> global::Microsoft.Graph.IServicePrincipal.AppRoleAssignedTo

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IAppRoleAssignment, global::Microsoft.Graph.AppRoleAssignment>(Context, (DataServiceCollection<global::Microsoft.Graph.AppRoleAssignment>)AppRoleAssignedTo);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IAppRoleAssignment> global::Microsoft.Graph.IServicePrincipal.AppRoleAssignments

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IAppRoleAssignment, global::Microsoft.Graph.AppRoleAssignment>(Context, (DataServiceCollection<global::Microsoft.Graph.AppRoleAssignment>)AppRoleAssignments);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IOAuth2PermissionGrant> global::Microsoft.Graph.IServicePrincipal.Oauth2PermissionGrants

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IOAuth2PermissionGrant, global::Microsoft.Graph.OAuth2PermissionGrant>(Context, (DataServiceCollection<global::Microsoft.Graph.OAuth2PermissionGrant>)Oauth2PermissionGrants);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IServicePrincipal.MemberOf

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)MemberOf);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IServicePrincipal.CreatedObjects

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)CreatedObjects);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IServicePrincipal.Owners

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)Owners);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IServicePrincipal.OwnedObjects

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)OwnedObjects);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AccountEnabled instead.")]

        public System.Nullable<System.Boolean> accountEnabled

        {

            get

            {

                return AccountEnabled;

            }

            set

            {

                AccountEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AddIns instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AddIn> addIns

        {

            get

            {

                return AddIns;

            }

            set

            {

                AddIns = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppDisplayName instead.")]

        public System.String appDisplayName

        {

            get

            {

                return AppDisplayName;

            }

            set

            {

                AppDisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppId instead.")]

        public System.String appId

        {

            get

            {

                return AppId;

            }

            set

            {

                AppId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppOwnerOrganizationId instead.")]

        public System.Nullable<System.Guid> appOwnerOrganizationId

        {

            get

            {

                return AppOwnerOrganizationId;

            }

            set

            {

                AppOwnerOrganizationId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppRoleAssignmentRequired instead.")]

        public System.Boolean appRoleAssignmentRequired

        {

            get

            {

                return AppRoleAssignmentRequired;

            }

            set

            {

                AppRoleAssignmentRequired = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppRoles instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRole> appRoles

        {

            get

            {

                return AppRoles;

            }

            set

            {

                AppRoles = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ErrorUrl instead.")]

        public System.String errorUrl

        {

            get

            {

                return ErrorUrl;

            }

            set

            {

                ErrorUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Homepage instead.")]

        public System.String homepage

        {

            get

            {

                return Homepage;

            }

            set

            {

                Homepage = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use KeyCredentials instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.KeyCredential> keyCredentials

        {

            get

            {

                return KeyCredentials;

            }

            set

            {

                KeyCredentials = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use LogoutUrl instead.")]

        public System.String logoutUrl

        {

            get

            {

                return LogoutUrl;

            }

            set

            {

                LogoutUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Oauth2Permissions instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2Permission> oauth2Permissions

        {

            get

            {

                return Oauth2Permissions;

            }

            set

            {

                Oauth2Permissions = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PasswordCredentials instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.PasswordCredential> passwordCredentials

        {

            get

            {

                return PasswordCredentials;

            }

            set

            {

                PasswordCredentials = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PreferredTokenSigningKeyThumbprint instead.")]

        public System.String preferredTokenSigningKeyThumbprint

        {

            get

            {

                return PreferredTokenSigningKeyThumbprint;

            }

            set

            {

                PreferredTokenSigningKeyThumbprint = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PublisherName instead.")]

        public System.String publisherName

        {

            get

            {

                return PublisherName;

            }

            set

            {

                PublisherName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ReplyUrls instead.")]

        public global::System.Collections.Generic.IList<System.String> replyUrls

        {

            get

            {

                return ReplyUrls;

            }

            set

            {

                ReplyUrls = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SamlMetadataUrl instead.")]

        public System.String samlMetadataUrl

        {

            get

            {

                return SamlMetadataUrl;

            }

            set

            {

                SamlMetadataUrl = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ServicePrincipalNames instead.")]

        public global::System.Collections.Generic.IList<System.String> servicePrincipalNames

        {

            get

            {

                return ServicePrincipalNames;

            }

            set

            {

                ServicePrincipalNames = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Tags instead.")]

        public global::System.Collections.Generic.IList<System.String> tags

        {

            get

            {

                return Tags;

            }

            set

            {

                Tags = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppRoleAssignedTo instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRoleAssignment> appRoleAssignedTo

        {

            get

            {

                return AppRoleAssignedTo;

            }

            set

            {

                AppRoleAssignedTo = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppRoleAssignments instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRoleAssignment> appRoleAssignments

        {

            get

            {

                return AppRoleAssignments;

            }

            set

            {

                AppRoleAssignments = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Oauth2PermissionGrants instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2PermissionGrant> oauth2PermissionGrants

        {

            get

            {

                return Oauth2PermissionGrants;

            }

            set

            {

                Oauth2PermissionGrants = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MemberOf instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> memberOf

        {

            get

            {

                return MemberOf;

            }

            set

            {

                MemberOf = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedObjects instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> createdObjects

        {

            get

            {

                return CreatedObjects;

            }

            set

            {

                CreatedObjects = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Owners instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> owners

        {

            get

            {

                return Owners;

            }

            set

            {

                Owners = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OwnedObjects instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> ownedObjects

        {

            get

            {

                return OwnedObjects;

            }

            set

            {

                OwnedObjects = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRoleAssignment> AppRoleAssignedTo

        {

            get

            {

                if (this._appRoleAssignedToConcrete == null)

                {

                    this._appRoleAssignedToConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.AppRoleAssignment>();

                    this._appRoleAssignedToConcrete.SetContainer(() => GetContainingEntity("appRoleAssignedTo"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRoleAssignment>)this._appRoleAssignedToConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                AppRoleAssignedTo.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AppRoleAssignedTo.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRoleAssignment> AppRoleAssignments

        {

            get

            {

                if (this._appRoleAssignmentsConcrete == null)

                {

                    this._appRoleAssignmentsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.AppRoleAssignment>();

                    this._appRoleAssignmentsConcrete.SetContainer(() => GetContainingEntity("appRoleAssignments"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.AppRoleAssignment>)this._appRoleAssignmentsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                AppRoleAssignments.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AppRoleAssignments.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2PermissionGrant> Oauth2PermissionGrants

        {

            get

            {

                if (this._oauth2PermissionGrantsConcrete == null)

                {

                    this._oauth2PermissionGrantsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.OAuth2PermissionGrant>();

                    this._oauth2PermissionGrantsConcrete.SetContainer(() => GetContainingEntity("oauth2PermissionGrants"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.OAuth2PermissionGrant>)this._oauth2PermissionGrantsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Oauth2PermissionGrants.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Oauth2PermissionGrants.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> MemberOf

        {

            get

            {

                if (this._memberOfConcrete == null)

                {

                    this._memberOfConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._memberOfConcrete.SetContainer(() => GetContainingEntity("memberOf"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._memberOfConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                MemberOf.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        MemberOf.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> CreatedObjects

        {

            get

            {

                if (this._createdObjectsConcrete == null)

                {

                    this._createdObjectsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._createdObjectsConcrete.SetContainer(() => GetContainingEntity("createdObjects"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._createdObjectsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                CreatedObjects.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CreatedObjects.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> Owners

        {

            get

            {

                if (this._ownersConcrete == null)

                {

                    this._ownersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._ownersConcrete.SetContainer(() => GetContainingEntity("owners"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._ownersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Owners.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Owners.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> OwnedObjects

        {

            get

            {

                if (this._ownedObjectsConcrete == null)

                {

                    this._ownedObjectsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._ownedObjectsConcrete.SetContainer(() => GetContainingEntity("ownedObjects"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._ownedObjectsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                OwnedObjects.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        OwnedObjects.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IAppRoleAssignmentCollection global::Microsoft.Graph.IServicePrincipalFetcher.AppRoleAssignedTo

        {

            get

            {

                if (this._appRoleAssignedToCollection == null)

                {

                    this._appRoleAssignedToCollection = new global::Microsoft.Graph.AppRoleAssignmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.AppRoleAssignment>(GetPath("appRoleAssignedTo")) : null,
                       Context,
                       this,
                       GetPath("appRoleAssignedTo"));

                }



                return this._appRoleAssignedToCollection;

            }

        }

        global::Microsoft.Graph.IAppRoleAssignmentCollection global::Microsoft.Graph.IServicePrincipalFetcher.AppRoleAssignments

        {

            get

            {

                if (this._appRoleAssignmentsCollection == null)

                {

                    this._appRoleAssignmentsCollection = new global::Microsoft.Graph.AppRoleAssignmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.AppRoleAssignment>(GetPath("appRoleAssignments")) : null,
                       Context,
                       this,
                       GetPath("appRoleAssignments"));

                }



                return this._appRoleAssignmentsCollection;

            }

        }

        global::Microsoft.Graph.IOAuth2PermissionGrantCollection global::Microsoft.Graph.IServicePrincipalFetcher.Oauth2PermissionGrants

        {

            get

            {

                if (this._oauth2PermissionGrantsCollection == null)

                {

                    this._oauth2PermissionGrantsCollection = new global::Microsoft.Graph.OAuth2PermissionGrantCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.OAuth2PermissionGrant>(GetPath("oauth2PermissionGrants")) : null,
                       Context,
                       this,
                       GetPath("oauth2PermissionGrants"));

                }



                return this._oauth2PermissionGrantsCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IServicePrincipalFetcher.MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IServicePrincipalFetcher.CreatedObjects

        {

            get

            {

                if (this._createdObjectsCollection == null)

                {

                    this._createdObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("createdObjects")) : null,
                       Context,
                       this,
                       GetPath("createdObjects"));

                }



                return this._createdObjectsCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IServicePrincipalFetcher.Owners

        {

            get

            {

                if (this._ownersCollection == null)

                {

                    this._ownersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("owners")) : null,
                       Context,
                       this,
                       GetPath("owners"));

                }



                return this._ownersCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IServicePrincipalFetcher.OwnedObjects

        {

            get

            {

                if (this._ownedObjectsCollection == null)

                {

                    this._ownedObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("ownedObjects")) : null,
                       Context,
                       this,
                       GetPath("ownedObjects"));

                }



                return this._ownedObjectsCollection;

            }

        }

        public ServicePrincipal()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IServicePrincipal> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ServicePrincipal, global::Microsoft.Graph.IServicePrincipal>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IServicePrincipal> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IServicePrincipal> global::Microsoft.Graph.IServicePrincipalFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IServicePrincipal>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IServicePrincipalFetcher global::Microsoft.Graph.IServicePrincipalFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IServicePrincipal, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IServicePrincipalFetcher)this;

        }

    }

    internal partial class ServicePrincipalFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IServicePrincipalFetcher

    {

        private global::Microsoft.Graph.AppRoleAssignmentCollection _appRoleAssignedToCollection;

        private global::Microsoft.Graph.AppRoleAssignmentCollection _appRoleAssignmentsCollection;

        private global::Microsoft.Graph.OAuth2PermissionGrantCollection _oauth2PermissionGrantsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _createdObjectsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownersCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownedObjectsCollection;

        public global::Microsoft.Graph.IAppRoleAssignmentCollection AppRoleAssignedTo

        {

            get

            {

                if (this._appRoleAssignedToCollection == null)

                {

                    this._appRoleAssignedToCollection = new global::Microsoft.Graph.AppRoleAssignmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.AppRoleAssignment>(GetPath("appRoleAssignedTo")) : null,
                       Context,
                       this,
                       GetPath("appRoleAssignedTo"));

                }



                return this._appRoleAssignedToCollection;

            }

        }

        public global::Microsoft.Graph.IAppRoleAssignmentCollection AppRoleAssignments

        {

            get

            {

                if (this._appRoleAssignmentsCollection == null)

                {

                    this._appRoleAssignmentsCollection = new global::Microsoft.Graph.AppRoleAssignmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.AppRoleAssignment>(GetPath("appRoleAssignments")) : null,
                       Context,
                       this,
                       GetPath("appRoleAssignments"));

                }



                return this._appRoleAssignmentsCollection;

            }

        }

        public global::Microsoft.Graph.IOAuth2PermissionGrantCollection Oauth2PermissionGrants

        {

            get

            {

                if (this._oauth2PermissionGrantsCollection == null)

                {

                    this._oauth2PermissionGrantsCollection = new global::Microsoft.Graph.OAuth2PermissionGrantCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.OAuth2PermissionGrant>(GetPath("oauth2PermissionGrants")) : null,
                       Context,
                       this,
                       GetPath("oauth2PermissionGrants"));

                }



                return this._oauth2PermissionGrantsCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection CreatedObjects

        {

            get

            {

                if (this._createdObjectsCollection == null)

                {

                    this._createdObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("createdObjects")) : null,
                       Context,
                       this,
                       GetPath("createdObjects"));

                }



                return this._createdObjectsCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection Owners

        {

            get

            {

                if (this._ownersCollection == null)

                {

                    this._ownersCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("owners")) : null,
                       Context,
                       this,
                       GetPath("owners"));

                }



                return this._ownersCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection OwnedObjects

        {

            get

            {

                if (this._ownedObjectsCollection == null)

                {

                    this._ownedObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("ownedObjects")) : null,
                       Context,
                       this,
                       GetPath("ownedObjects"));

                }



                return this._ownedObjectsCollection;

            }

        }

        public ServicePrincipalFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IServicePrincipal> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IServicePrincipalFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IServicePrincipal, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IServicePrincipalFetcher)new global::Microsoft.Graph.ServicePrincipalFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IServicePrincipal> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.ServicePrincipal, global::Microsoft.Graph.IServicePrincipal>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IServicePrincipal> _query;

    }

    internal partial class ServicePrincipalCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IServicePrincipal>, global::Microsoft.Graph.IServicePrincipalCollection

    {

        internal ServicePrincipalCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IServicePrincipalFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IServicePrincipal>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddservicePrincipalAsync(global::Microsoft.Graph.IServicePrincipal item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IServicePrincipalFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.ServicePrincipal>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.ServicePrincipalFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class ServicePrincipalCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class SubscribedSku : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.ISubscribedSku, global::Microsoft.Graph.ISubscribedSkuFetcher

    {

        private System.String _capabilityStatus;

        private System.Nullable<System.Int32> _consumedUnits;

        private System.String _id;

        private global::Microsoft.Graph.LicenseUnitsDetail _prepaidUnits;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ServicePlanInfo> _servicePlans;

        private System.Nullable<System.Guid> _skuId;

        private System.String _skuPartNumber;

        private System.String _appliesTo;

        public System.String CapabilityStatus

        {

            get

            {

                return _capabilityStatus;

            }

            set

            {

                if (value != _capabilityStatus)

                {

                    _capabilityStatus = value;

                    OnPropertyChanged("capabilityStatus");

                }

            }

        }

        public System.Nullable<System.Int32> ConsumedUnits

        {

            get

            {

                return _consumedUnits;

            }

            set

            {

                if (value != _consumedUnits)

                {

                    _consumedUnits = value;

                    OnPropertyChanged("consumedUnits");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        public global::Microsoft.Graph.LicenseUnitsDetail PrepaidUnits

        {

            get

            {

                return _prepaidUnits;

            }

            set

            {

                if (value != _prepaidUnits)

                {

                    _prepaidUnits = value;

                    OnPropertyChanged("prepaidUnits");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.ServicePlanInfo> ServicePlans

        {

            get

            {

                if (this._servicePlans == default(System.Collections.Generic.IList<global::Microsoft.Graph.ServicePlanInfo>))

                {

                    this._servicePlans = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ServicePlanInfo>();

                    this._servicePlans.SetContainer(() => GetContainingEntity("servicePlans"));

                }

                return this._servicePlans;

            }

            set

            {

                ServicePlans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ServicePlans.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.Guid> SkuId

        {

            get

            {

                return _skuId;

            }

            set

            {

                if (value != _skuId)

                {

                    _skuId = value;

                    OnPropertyChanged("skuId");

                }

            }

        }

        public System.String SkuPartNumber

        {

            get

            {

                return _skuPartNumber;

            }

            set

            {

                if (value != _skuPartNumber)

                {

                    _skuPartNumber = value;

                    OnPropertyChanged("skuPartNumber");

                }

            }

        }

        public System.String AppliesTo

        {

            get

            {

                return _appliesTo;

            }

            set

            {

                if (value != _appliesTo)

                {

                    _appliesTo = value;

                    OnPropertyChanged("appliesTo");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CapabilityStatus instead.")]

        public System.String capabilityStatus

        {

            get

            {

                return CapabilityStatus;

            }

            set

            {

                CapabilityStatus = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ConsumedUnits instead.")]

        public System.Nullable<System.Int32> consumedUnits

        {

            get

            {

                return ConsumedUnits;

            }

            set

            {

                ConsumedUnits = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PrepaidUnits instead.")]

        public global::Microsoft.Graph.LicenseUnitsDetail prepaidUnits

        {

            get

            {

                return PrepaidUnits;

            }

            set

            {

                PrepaidUnits = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ServicePlans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ServicePlanInfo> servicePlans

        {

            get

            {

                return ServicePlans;

            }

            set

            {

                ServicePlans = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SkuId instead.")]

        public System.Nullable<System.Guid> skuId

        {

            get

            {

                return SkuId;

            }

            set

            {

                SkuId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SkuPartNumber instead.")]

        public System.String skuPartNumber

        {

            get

            {

                return SkuPartNumber;

            }

            set

            {

                SkuPartNumber = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AppliesTo instead.")]

        public System.String appliesTo

        {

            get

            {

                return AppliesTo;

            }

            set

            {

                AppliesTo = value;

            }

        }

        public SubscribedSku() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ISubscribedSku> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.SubscribedSku, global::Microsoft.Graph.ISubscribedSku>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ISubscribedSku> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.ISubscribedSku> global::Microsoft.Graph.ISubscribedSkuFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.ISubscribedSku>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.ISubscribedSkuFetcher global::Microsoft.Graph.ISubscribedSkuFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.ISubscribedSku, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.ISubscribedSkuFetcher)this;

        }

    }

    internal partial class SubscribedSkuFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.ISubscribedSkuFetcher

    {

        public SubscribedSkuFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.ISubscribedSku> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.ISubscribedSkuFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.ISubscribedSku, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.ISubscribedSkuFetcher)new global::Microsoft.Graph.SubscribedSkuFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ISubscribedSku> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.SubscribedSku, global::Microsoft.Graph.ISubscribedSku>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ISubscribedSku> _query;

    }

    internal partial class SubscribedSkuCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.ISubscribedSku>, global::Microsoft.Graph.ISubscribedSkuCollection

    {

        internal SubscribedSkuCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.ISubscribedSkuFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ISubscribedSku>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddsubscribedSkuAsync(global::Microsoft.Graph.ISubscribedSku item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.ISubscribedSkuFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.SubscribedSku>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.SubscribedSkuFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class SubscribedSkuCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Organization : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IOrganization, global::Microsoft.Graph.IOrganizationFetcher

    {

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AssignedPlan> _assignedPlans;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _businessPhones;

        private System.String _city;

        private System.String _country;

        private System.String _countryLetterCode;

        private System.String _displayName;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _marketingNotificationEmails;

        private System.Nullable<System.DateTimeOffset> _onPremisesLastSyncDateTime;

        private System.Nullable<System.Boolean> _onPremisesSyncEnabled;

        private System.String _postalCode;

        private System.String _preferredLanguage;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ProvisionedPlan> _provisionedPlans;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _securityComplianceNotificationMails;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _securityComplianceNotificationPhones;

        private System.String _state;

        private System.String _street;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _technicalNotificationMails;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.VerifiedDomain> _verifiedDomains;

        public System.Collections.Generic.IList<global::Microsoft.Graph.AssignedPlan> AssignedPlans

        {

            get

            {

                if (this._assignedPlans == default(System.Collections.Generic.IList<global::Microsoft.Graph.AssignedPlan>))

                {

                    this._assignedPlans = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AssignedPlan>();

                    this._assignedPlans.SetContainer(() => GetContainingEntity("assignedPlans"));

                }

                return this._assignedPlans;

            }

            set

            {

                AssignedPlans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AssignedPlans.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> BusinessPhones

        {

            get

            {

                if (this._businessPhones == default(System.Collections.Generic.IList<System.String>))

                {

                    this._businessPhones = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._businessPhones.SetContainer(() => GetContainingEntity("businessPhones"));

                }

                return this._businessPhones;

            }

            set

            {

                BusinessPhones.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        BusinessPhones.Add(i);

                    }

                }

            }

        }

        public System.String City

        {

            get

            {

                return _city;

            }

            set

            {

                if (value != _city)

                {

                    _city = value;

                    OnPropertyChanged("city");

                }

            }

        }

        public System.String Country

        {

            get

            {

                return _country;

            }

            set

            {

                if (value != _country)

                {

                    _country = value;

                    OnPropertyChanged("country");

                }

            }

        }

        public System.String CountryLetterCode

        {

            get

            {

                return _countryLetterCode;

            }

            set

            {

                if (value != _countryLetterCode)

                {

                    _countryLetterCode = value;

                    OnPropertyChanged("countryLetterCode");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> MarketingNotificationEmails

        {

            get

            {

                if (this._marketingNotificationEmails == default(System.Collections.Generic.IList<System.String>))

                {

                    this._marketingNotificationEmails = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._marketingNotificationEmails.SetContainer(() => GetContainingEntity("marketingNotificationEmails"));

                }

                return this._marketingNotificationEmails;

            }

            set

            {

                MarketingNotificationEmails.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        MarketingNotificationEmails.Add(i);

                    }

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> OnPremisesLastSyncDateTime

        {

            get

            {

                return _onPremisesLastSyncDateTime;

            }

            set

            {

                if (value != _onPremisesLastSyncDateTime)

                {

                    _onPremisesLastSyncDateTime = value;

                    OnPropertyChanged("onPremisesLastSyncDateTime");

                }

            }

        }

        public System.Nullable<System.Boolean> OnPremisesSyncEnabled

        {

            get

            {

                return _onPremisesSyncEnabled;

            }

            set

            {

                if (value != _onPremisesSyncEnabled)

                {

                    _onPremisesSyncEnabled = value;

                    OnPropertyChanged("onPremisesSyncEnabled");

                }

            }

        }

        public System.String PostalCode

        {

            get

            {

                return _postalCode;

            }

            set

            {

                if (value != _postalCode)

                {

                    _postalCode = value;

                    OnPropertyChanged("postalCode");

                }

            }

        }

        public System.String PreferredLanguage

        {

            get

            {

                return _preferredLanguage;

            }

            set

            {

                if (value != _preferredLanguage)

                {

                    _preferredLanguage = value;

                    OnPropertyChanged("preferredLanguage");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.ProvisionedPlan> ProvisionedPlans

        {

            get

            {

                if (this._provisionedPlans == default(System.Collections.Generic.IList<global::Microsoft.Graph.ProvisionedPlan>))

                {

                    this._provisionedPlans = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ProvisionedPlan>();

                    this._provisionedPlans.SetContainer(() => GetContainingEntity("provisionedPlans"));

                }

                return this._provisionedPlans;

            }

            set

            {

                ProvisionedPlans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ProvisionedPlans.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> SecurityComplianceNotificationMails

        {

            get

            {

                if (this._securityComplianceNotificationMails == default(System.Collections.Generic.IList<System.String>))

                {

                    this._securityComplianceNotificationMails = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._securityComplianceNotificationMails.SetContainer(() => GetContainingEntity("securityComplianceNotificationMails"));

                }

                return this._securityComplianceNotificationMails;

            }

            set

            {

                SecurityComplianceNotificationMails.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        SecurityComplianceNotificationMails.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> SecurityComplianceNotificationPhones

        {

            get

            {

                if (this._securityComplianceNotificationPhones == default(System.Collections.Generic.IList<System.String>))

                {

                    this._securityComplianceNotificationPhones = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._securityComplianceNotificationPhones.SetContainer(() => GetContainingEntity("securityComplianceNotificationPhones"));

                }

                return this._securityComplianceNotificationPhones;

            }

            set

            {

                SecurityComplianceNotificationPhones.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        SecurityComplianceNotificationPhones.Add(i);

                    }

                }

            }

        }

        public System.String State

        {

            get

            {

                return _state;

            }

            set

            {

                if (value != _state)

                {

                    _state = value;

                    OnPropertyChanged("state");

                }

            }

        }

        public System.String Street

        {

            get

            {

                return _street;

            }

            set

            {

                if (value != _street)

                {

                    _street = value;

                    OnPropertyChanged("street");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> TechnicalNotificationMails

        {

            get

            {

                if (this._technicalNotificationMails == default(System.Collections.Generic.IList<System.String>))

                {

                    this._technicalNotificationMails = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._technicalNotificationMails.SetContainer(() => GetContainingEntity("technicalNotificationMails"));

                }

                return this._technicalNotificationMails;

            }

            set

            {

                TechnicalNotificationMails.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        TechnicalNotificationMails.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.VerifiedDomain> VerifiedDomains

        {

            get

            {

                if (this._verifiedDomains == default(System.Collections.Generic.IList<global::Microsoft.Graph.VerifiedDomain>))

                {

                    this._verifiedDomains = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.VerifiedDomain>();

                    this._verifiedDomains.SetContainer(() => GetContainingEntity("verifiedDomains"));

                }

                return this._verifiedDomains;

            }

            set

            {

                VerifiedDomains.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        VerifiedDomains.Add(i);

                    }

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AssignedPlans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AssignedPlan> assignedPlans

        {

            get

            {

                return AssignedPlans;

            }

            set

            {

                AssignedPlans = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BusinessPhones instead.")]

        public global::System.Collections.Generic.IList<System.String> businessPhones

        {

            get

            {

                return BusinessPhones;

            }

            set

            {

                BusinessPhones = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use City instead.")]

        public System.String city

        {

            get

            {

                return City;

            }

            set

            {

                City = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Country instead.")]

        public System.String country

        {

            get

            {

                return Country;

            }

            set

            {

                Country = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CountryLetterCode instead.")]

        public System.String countryLetterCode

        {

            get

            {

                return CountryLetterCode;

            }

            set

            {

                CountryLetterCode = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MarketingNotificationEmails instead.")]

        public global::System.Collections.Generic.IList<System.String> marketingNotificationEmails

        {

            get

            {

                return MarketingNotificationEmails;

            }

            set

            {

                MarketingNotificationEmails = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesLastSyncDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> onPremisesLastSyncDateTime

        {

            get

            {

                return OnPremisesLastSyncDateTime;

            }

            set

            {

                OnPremisesLastSyncDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSyncEnabled instead.")]

        public System.Nullable<System.Boolean> onPremisesSyncEnabled

        {

            get

            {

                return OnPremisesSyncEnabled;

            }

            set

            {

                OnPremisesSyncEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PostalCode instead.")]

        public System.String postalCode

        {

            get

            {

                return PostalCode;

            }

            set

            {

                PostalCode = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PreferredLanguage instead.")]

        public System.String preferredLanguage

        {

            get

            {

                return PreferredLanguage;

            }

            set

            {

                PreferredLanguage = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProvisionedPlans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ProvisionedPlan> provisionedPlans

        {

            get

            {

                return ProvisionedPlans;

            }

            set

            {

                ProvisionedPlans = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SecurityComplianceNotificationMails instead.")]

        public global::System.Collections.Generic.IList<System.String> securityComplianceNotificationMails

        {

            get

            {

                return SecurityComplianceNotificationMails;

            }

            set

            {

                SecurityComplianceNotificationMails = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SecurityComplianceNotificationPhones instead.")]

        public global::System.Collections.Generic.IList<System.String> securityComplianceNotificationPhones

        {

            get

            {

                return SecurityComplianceNotificationPhones;

            }

            set

            {

                SecurityComplianceNotificationPhones = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use State instead.")]

        public System.String state

        {

            get

            {

                return State;

            }

            set

            {

                State = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Street instead.")]

        public System.String street

        {

            get

            {

                return Street;

            }

            set

            {

                Street = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TechnicalNotificationMails instead.")]

        public global::System.Collections.Generic.IList<System.String> technicalNotificationMails

        {

            get

            {

                return TechnicalNotificationMails;

            }

            set

            {

                TechnicalNotificationMails = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use VerifiedDomains instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.VerifiedDomain> verifiedDomains

        {

            get

            {

                return VerifiedDomains;

            }

            set

            {

                VerifiedDomains = value;

            }

        }

        public Organization()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrganization> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Organization, global::Microsoft.Graph.IOrganization>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrganization> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IOrganization> global::Microsoft.Graph.IOrganizationFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IOrganization>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IOrganizationFetcher global::Microsoft.Graph.IOrganizationFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IOrganization, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IOrganizationFetcher)this;

        }

    }

    internal partial class OrganizationFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IOrganizationFetcher

    {

        public OrganizationFetcher()

        {

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IOrganization> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IOrganizationFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IOrganization, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IOrganizationFetcher)new global::Microsoft.Graph.OrganizationFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrganization> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Organization, global::Microsoft.Graph.IOrganization>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IOrganization> _query;

    }

    internal partial class OrganizationCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IOrganization>, global::Microsoft.Graph.IOrganizationCollection

    {

        internal OrganizationCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IOrganizationFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IOrganization>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddorganizationAsync(global::Microsoft.Graph.IOrganization item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IOrganizationFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Organization>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.OrganizationFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class OrganizationCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class User : global::Microsoft.Graph.DirectoryObject, global::Microsoft.Graph.IUser, global::Microsoft.Graph.IUserFetcher

    {

        private global::Microsoft.Graph.DirectoryObject _manager;

        private global::Microsoft.Graph.Calendar _calendar;

        private global::Microsoft.Graph.InferenceClassification _inferenceClassification;

        private global::Microsoft.Graph.ProfilePhoto _photo;

        private global::Microsoft.Graph.Drive _drive;

        private global::Microsoft.Graph.Notes _notes;

        private global::Microsoft.Graph.DirectoryObjectFetcher _managerFetcher;

        private global::Microsoft.Graph.CalendarFetcher _calendarFetcher;

        private global::Microsoft.Graph.InferenceClassificationFetcher _inferenceClassificationFetcher;

        private global::Microsoft.Graph.ProfilePhotoFetcher _photoFetcher;

        private global::Microsoft.Graph.DriveFetcher _driveFetcher;

        private global::Microsoft.Graph.NotesFetcher _notesFetcher;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownedDevicesCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _registeredDevicesCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _directReportsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _createdObjectsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownedObjectsCollection;

        private global::Microsoft.Graph.MessageCollection _messagesCollection;

        private global::Microsoft.Graph.GroupCollection _joinedGroupsCollection;

        private global::Microsoft.Graph.MailFolderCollection _mailFoldersCollection;

        private global::Microsoft.Graph.CalendarCollection _calendarsCollection;

        private global::Microsoft.Graph.CalendarGroupCollection _calendarGroupsCollection;

        private global::Microsoft.Graph.EventCollection _calendarViewCollection;

        private global::Microsoft.Graph.EventCollection _eventsCollection;

        private global::Microsoft.Graph.PersonCollection _peopleCollection;

        private global::Microsoft.Graph.ContactCollection _contactsCollection;

        private global::Microsoft.Graph.ContactFolderCollection _contactFoldersCollection;

        private global::Microsoft.Graph.ProfilePhotoCollection _photosCollection;

        private global::Microsoft.Graph.DriveItemCollection _TrendingAroundCollection;

        private global::Microsoft.Graph.UserCollection _WorkingWithCollection;

        private global::Microsoft.Graph.TaskCollection _tasksCollection;

        private global::Microsoft.Graph.PlanCollection _plansCollection;

        private System.Nullable<System.Boolean> _accountEnabled;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AssignedLicense> _assignedLicenses;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AssignedPlan> _assignedPlans;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _businessPhones;

        private System.String _city;

        private System.String _companyName;

        private System.String _country;

        private System.String _department;

        private System.String _displayName;

        private System.String _givenName;

        private System.String _jobTitle;

        private System.String _mail;

        private System.String _mailNickname;

        private System.String _mobilePhone;

        private System.String _onPremisesImmutableId;

        private System.Nullable<System.DateTimeOffset> _onPremisesLastSyncDateTime;

        private System.String _onPremisesSecurityIdentifier;

        private System.Nullable<System.Boolean> _onPremisesSyncEnabled;

        private System.String _passwordPolicies;

        private global::Microsoft.Graph.PasswordProfile _passwordProfile;

        private System.String _officeLocation;

        private System.String _postalCode;

        private System.String _preferredLanguage;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ProvisionedPlan> _provisionedPlans;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _proxyAddresses;

        private System.String _state;

        private System.String _streetAddress;

        private System.String _surname;

        private System.String _usageLocation;

        private System.String _userPrincipalName;

        private System.String _userType;

        private System.String _aboutMe;

        private System.DateTimeOffset _birthday;

        private System.DateTimeOffset _hireDate;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _interests;

        private System.String _mySite;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _pastProjects;

        private System.String _preferredName;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _responsibilities;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _schools;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _skills;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _ownedDevicesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _registeredDevicesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _directReportsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _memberOfConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _createdObjectsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject> _ownedObjectsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Message> _messagesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Group> _joinedGroupsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.MailFolder> _mailFoldersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Calendar> _calendarsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.CalendarGroup> _calendarGroupsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _calendarViewConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event> _eventsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Person> _peopleConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Contact> _contactsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ContactFolder> _contactFoldersConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ProfilePhoto> _photosConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem> _TrendingAroundConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.User> _WorkingWithConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Task> _tasksConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Plan> _plansConcrete;

        public System.Nullable<System.Boolean> AccountEnabled

        {

            get

            {

                return _accountEnabled;

            }

            set

            {

                if (value != _accountEnabled)

                {

                    _accountEnabled = value;

                    OnPropertyChanged("accountEnabled");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AssignedLicense> AssignedLicenses

        {

            get

            {

                if (this._assignedLicenses == default(System.Collections.Generic.IList<global::Microsoft.Graph.AssignedLicense>))

                {

                    this._assignedLicenses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AssignedLicense>();

                    this._assignedLicenses.SetContainer(() => GetContainingEntity("assignedLicenses"));

                }

                return this._assignedLicenses;

            }

            set

            {

                AssignedLicenses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AssignedLicenses.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.AssignedPlan> AssignedPlans

        {

            get

            {

                if (this._assignedPlans == default(System.Collections.Generic.IList<global::Microsoft.Graph.AssignedPlan>))

                {

                    this._assignedPlans = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.AssignedPlan>();

                    this._assignedPlans.SetContainer(() => GetContainingEntity("assignedPlans"));

                }

                return this._assignedPlans;

            }

            set

            {

                AssignedPlans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        AssignedPlans.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> BusinessPhones

        {

            get

            {

                if (this._businessPhones == default(System.Collections.Generic.IList<System.String>))

                {

                    this._businessPhones = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._businessPhones.SetContainer(() => GetContainingEntity("businessPhones"));

                }

                return this._businessPhones;

            }

            set

            {

                BusinessPhones.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        BusinessPhones.Add(i);

                    }

                }

            }

        }

        public System.String City

        {

            get

            {

                return _city;

            }

            set

            {

                if (value != _city)

                {

                    _city = value;

                    OnPropertyChanged("city");

                }

            }

        }

        public System.String CompanyName

        {

            get

            {

                return _companyName;

            }

            set

            {

                if (value != _companyName)

                {

                    _companyName = value;

                    OnPropertyChanged("companyName");

                }

            }

        }

        public System.String Country

        {

            get

            {

                return _country;

            }

            set

            {

                if (value != _country)

                {

                    _country = value;

                    OnPropertyChanged("country");

                }

            }

        }

        public System.String Department

        {

            get

            {

                return _department;

            }

            set

            {

                if (value != _department)

                {

                    _department = value;

                    OnPropertyChanged("department");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String GivenName

        {

            get

            {

                return _givenName;

            }

            set

            {

                if (value != _givenName)

                {

                    _givenName = value;

                    OnPropertyChanged("givenName");

                }

            }

        }

        public System.String JobTitle

        {

            get

            {

                return _jobTitle;

            }

            set

            {

                if (value != _jobTitle)

                {

                    _jobTitle = value;

                    OnPropertyChanged("jobTitle");

                }

            }

        }

        public System.String Mail

        {

            get

            {

                return _mail;

            }

            set

            {

                if (value != _mail)

                {

                    _mail = value;

                    OnPropertyChanged("mail");

                }

            }

        }

        public System.String MailNickname

        {

            get

            {

                return _mailNickname;

            }

            set

            {

                if (value != _mailNickname)

                {

                    _mailNickname = value;

                    OnPropertyChanged("mailNickname");

                }

            }

        }

        public System.String MobilePhone

        {

            get

            {

                return _mobilePhone;

            }

            set

            {

                if (value != _mobilePhone)

                {

                    _mobilePhone = value;

                    OnPropertyChanged("mobilePhone");

                }

            }

        }

        public System.String OnPremisesImmutableId

        {

            get

            {

                return _onPremisesImmutableId;

            }

            set

            {

                if (value != _onPremisesImmutableId)

                {

                    _onPremisesImmutableId = value;

                    OnPropertyChanged("onPremisesImmutableId");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> OnPremisesLastSyncDateTime

        {

            get

            {

                return _onPremisesLastSyncDateTime;

            }

            set

            {

                if (value != _onPremisesLastSyncDateTime)

                {

                    _onPremisesLastSyncDateTime = value;

                    OnPropertyChanged("onPremisesLastSyncDateTime");

                }

            }

        }

        public System.String OnPremisesSecurityIdentifier

        {

            get

            {

                return _onPremisesSecurityIdentifier;

            }

            set

            {

                if (value != _onPremisesSecurityIdentifier)

                {

                    _onPremisesSecurityIdentifier = value;

                    OnPropertyChanged("onPremisesSecurityIdentifier");

                }

            }

        }

        public System.Nullable<System.Boolean> OnPremisesSyncEnabled

        {

            get

            {

                return _onPremisesSyncEnabled;

            }

            set

            {

                if (value != _onPremisesSyncEnabled)

                {

                    _onPremisesSyncEnabled = value;

                    OnPropertyChanged("onPremisesSyncEnabled");

                }

            }

        }

        public System.String PasswordPolicies

        {

            get

            {

                return _passwordPolicies;

            }

            set

            {

                if (value != _passwordPolicies)

                {

                    _passwordPolicies = value;

                    OnPropertyChanged("passwordPolicies");

                }

            }

        }

        public global::Microsoft.Graph.PasswordProfile PasswordProfile

        {

            get

            {

                return _passwordProfile;

            }

            set

            {

                if (value != _passwordProfile)

                {

                    _passwordProfile = value;

                    OnPropertyChanged("passwordProfile");

                }

            }

        }

        public System.String OfficeLocation

        {

            get

            {

                return _officeLocation;

            }

            set

            {

                if (value != _officeLocation)

                {

                    _officeLocation = value;

                    OnPropertyChanged("officeLocation");

                }

            }

        }

        public System.String PostalCode

        {

            get

            {

                return _postalCode;

            }

            set

            {

                if (value != _postalCode)

                {

                    _postalCode = value;

                    OnPropertyChanged("postalCode");

                }

            }

        }

        public System.String PreferredLanguage

        {

            get

            {

                return _preferredLanguage;

            }

            set

            {

                if (value != _preferredLanguage)

                {

                    _preferredLanguage = value;

                    OnPropertyChanged("preferredLanguage");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.ProvisionedPlan> ProvisionedPlans

        {

            get

            {

                if (this._provisionedPlans == default(System.Collections.Generic.IList<global::Microsoft.Graph.ProvisionedPlan>))

                {

                    this._provisionedPlans = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.ProvisionedPlan>();

                    this._provisionedPlans.SetContainer(() => GetContainingEntity("provisionedPlans"));

                }

                return this._provisionedPlans;

            }

            set

            {

                ProvisionedPlans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ProvisionedPlans.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ProxyAddresses

        {

            get

            {

                if (this._proxyAddresses == default(System.Collections.Generic.IList<System.String>))

                {

                    this._proxyAddresses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._proxyAddresses.SetContainer(() => GetContainingEntity("proxyAddresses"));

                }

                return this._proxyAddresses;

            }

            set

            {

                ProxyAddresses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ProxyAddresses.Add(i);

                    }

                }

            }

        }

        public System.String State

        {

            get

            {

                return _state;

            }

            set

            {

                if (value != _state)

                {

                    _state = value;

                    OnPropertyChanged("state");

                }

            }

        }

        public System.String StreetAddress

        {

            get

            {

                return _streetAddress;

            }

            set

            {

                if (value != _streetAddress)

                {

                    _streetAddress = value;

                    OnPropertyChanged("streetAddress");

                }

            }

        }

        public System.String Surname

        {

            get

            {

                return _surname;

            }

            set

            {

                if (value != _surname)

                {

                    _surname = value;

                    OnPropertyChanged("surname");

                }

            }

        }

        public System.String UsageLocation

        {

            get

            {

                return _usageLocation;

            }

            set

            {

                if (value != _usageLocation)

                {

                    _usageLocation = value;

                    OnPropertyChanged("usageLocation");

                }

            }

        }

        public System.String UserPrincipalName

        {

            get

            {

                return _userPrincipalName;

            }

            set

            {

                if (value != _userPrincipalName)

                {

                    _userPrincipalName = value;

                    OnPropertyChanged("userPrincipalName");

                }

            }

        }

        public System.String UserType

        {

            get

            {

                return _userType;

            }

            set

            {

                if (value != _userType)

                {

                    _userType = value;

                    OnPropertyChanged("userType");

                }

            }

        }

        public System.String AboutMe

        {

            get

            {

                return _aboutMe;

            }

            set

            {

                if (value != _aboutMe)

                {

                    _aboutMe = value;

                    OnPropertyChanged("aboutMe");

                }

            }

        }

        public System.DateTimeOffset Birthday

        {

            get

            {

                return _birthday;

            }

            set

            {

                if (value != _birthday)

                {

                    _birthday = value;

                    OnPropertyChanged("birthday");

                }

            }

        }

        public System.DateTimeOffset HireDate

        {

            get

            {

                return _hireDate;

            }

            set

            {

                if (value != _hireDate)

                {

                    _hireDate = value;

                    OnPropertyChanged("hireDate");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Interests

        {

            get

            {

                if (this._interests == default(System.Collections.Generic.IList<System.String>))

                {

                    this._interests = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._interests.SetContainer(() => GetContainingEntity("interests"));

                }

                return this._interests;

            }

            set

            {

                Interests.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Interests.Add(i);

                    }

                }

            }

        }

        public System.String MySite

        {

            get

            {

                return _mySite;

            }

            set

            {

                if (value != _mySite)

                {

                    _mySite = value;

                    OnPropertyChanged("mySite");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> PastProjects

        {

            get

            {

                if (this._pastProjects == default(System.Collections.Generic.IList<System.String>))

                {

                    this._pastProjects = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._pastProjects.SetContainer(() => GetContainingEntity("pastProjects"));

                }

                return this._pastProjects;

            }

            set

            {

                PastProjects.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        PastProjects.Add(i);

                    }

                }

            }

        }

        public System.String PreferredName

        {

            get

            {

                return _preferredName;

            }

            set

            {

                if (value != _preferredName)

                {

                    _preferredName = value;

                    OnPropertyChanged("preferredName");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Responsibilities

        {

            get

            {

                if (this._responsibilities == default(System.Collections.Generic.IList<System.String>))

                {

                    this._responsibilities = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._responsibilities.SetContainer(() => GetContainingEntity("responsibilities"));

                }

                return this._responsibilities;

            }

            set

            {

                Responsibilities.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Responsibilities.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Schools

        {

            get

            {

                if (this._schools == default(System.Collections.Generic.IList<System.String>))

                {

                    this._schools = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._schools.SetContainer(() => GetContainingEntity("schools"));

                }

                return this._schools;

            }

            set

            {

                Schools.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Schools.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Skills

        {

            get

            {

                if (this._skills == default(System.Collections.Generic.IList<System.String>))

                {

                    this._skills = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._skills.SetContainer(() => GetContainingEntity("skills"));

                }

                return this._skills;

            }

            set

            {

                Skills.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Skills.Add(i);

                    }

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IUser.OwnedDevices

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)OwnedDevices);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IUser.RegisteredDevices

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)RegisteredDevices);

            }

        }

        global::Microsoft.Graph.IDirectoryObject global::Microsoft.Graph.IUser.Manager

        {

            get

            {

                return this._manager;

            }

            set

            {

                if (this.Manager != value)

                {

                    this.Manager = (global::Microsoft.Graph.DirectoryObject)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IUser.DirectReports

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)DirectReports);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IUser.MemberOf

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)MemberOf);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IUser.CreatedObjects

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)CreatedObjects);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDirectoryObject> global::Microsoft.Graph.IUser.OwnedObjects

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDirectoryObject, global::Microsoft.Graph.DirectoryObject>(Context, (DataServiceCollection<global::Microsoft.Graph.DirectoryObject>)OwnedObjects);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IMessage> global::Microsoft.Graph.IUser.Messages

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IMessage, global::Microsoft.Graph.Message>(Context, (DataServiceCollection<global::Microsoft.Graph.Message>)Messages);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IGroup> global::Microsoft.Graph.IUser.JoinedGroups

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IGroup, global::Microsoft.Graph.Group>(Context, (DataServiceCollection<global::Microsoft.Graph.Group>)JoinedGroups);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IMailFolder> global::Microsoft.Graph.IUser.MailFolders

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IMailFolder, global::Microsoft.Graph.MailFolder>(Context, (DataServiceCollection<global::Microsoft.Graph.MailFolder>)MailFolders);

            }

        }

        global::Microsoft.Graph.ICalendar global::Microsoft.Graph.IUser.Calendar

        {

            get

            {

                return this._calendar;

            }

            set

            {

                if (this.Calendar != value)

                {

                    this.Calendar = (global::Microsoft.Graph.Calendar)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ICalendar> global::Microsoft.Graph.IUser.Calendars

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ICalendar, global::Microsoft.Graph.Calendar>(Context, (DataServiceCollection<global::Microsoft.Graph.Calendar>)Calendars);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ICalendarGroup> global::Microsoft.Graph.IUser.CalendarGroups

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ICalendarGroup, global::Microsoft.Graph.CalendarGroup>(Context, (DataServiceCollection<global::Microsoft.Graph.CalendarGroup>)CalendarGroups);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.IUser.CalendarView

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)CalendarView);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IEvent> global::Microsoft.Graph.IUser.Events

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IEvent, global::Microsoft.Graph.Event>(Context, (DataServiceCollection<global::Microsoft.Graph.Event>)Events);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPerson> global::Microsoft.Graph.IUser.People

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IPerson, global::Microsoft.Graph.Person>(Context, (DataServiceCollection<global::Microsoft.Graph.Person>)People);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IContact> global::Microsoft.Graph.IUser.Contacts

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IContact, global::Microsoft.Graph.Contact>(Context, (DataServiceCollection<global::Microsoft.Graph.Contact>)Contacts);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IContactFolder> global::Microsoft.Graph.IUser.ContactFolders

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IContactFolder, global::Microsoft.Graph.ContactFolder>(Context, (DataServiceCollection<global::Microsoft.Graph.ContactFolder>)ContactFolders);

            }

        }

        global::Microsoft.Graph.IInferenceClassification global::Microsoft.Graph.IUser.InferenceClassification

        {

            get

            {

                return this._inferenceClassification;

            }

            set

            {

                if (this.InferenceClassification != value)

                {

                    this.InferenceClassification = (global::Microsoft.Graph.InferenceClassification)value;

                }

            }

        }

        global::Microsoft.Graph.IProfilePhoto global::Microsoft.Graph.IUser.Photo

        {

            get

            {

                return this._photo;

            }

            set

            {

                if (this.Photo != value)

                {

                    this.Photo = (global::Microsoft.Graph.ProfilePhoto)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IProfilePhoto> global::Microsoft.Graph.IUser.Photos

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IProfilePhoto, global::Microsoft.Graph.ProfilePhoto>(Context, (DataServiceCollection<global::Microsoft.Graph.ProfilePhoto>)Photos);

            }

        }

        global::Microsoft.Graph.IDrive global::Microsoft.Graph.IUser.Drive

        {

            get

            {

                return this._drive;

            }

            set

            {

                if (this.Drive != value)

                {

                    this.Drive = (global::Microsoft.Graph.Drive)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IDriveItem> global::Microsoft.Graph.IUser.TrendingAround

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IDriveItem, global::Microsoft.Graph.DriveItem>(Context, (DataServiceCollection<global::Microsoft.Graph.DriveItem>)TrendingAround);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IUser> global::Microsoft.Graph.IUser.WorkingWith

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IUser, global::Microsoft.Graph.User>(Context, (DataServiceCollection<global::Microsoft.Graph.User>)WorkingWith);

            }

        }

        global::Microsoft.Graph.INotes global::Microsoft.Graph.IUser.Notes

        {

            get

            {

                return this._notes;

            }

            set

            {

                if (this.Notes != value)

                {

                    this.Notes = (global::Microsoft.Graph.Notes)value;

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ITask> global::Microsoft.Graph.IUser.Tasks

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ITask, global::Microsoft.Graph.Task>(Context, (DataServiceCollection<global::Microsoft.Graph.Task>)Tasks);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPlan> global::Microsoft.Graph.IUser.Plans

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IPlan, global::Microsoft.Graph.Plan>(Context, (DataServiceCollection<global::Microsoft.Graph.Plan>)Plans);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AccountEnabled instead.")]

        public System.Nullable<System.Boolean> accountEnabled

        {

            get

            {

                return AccountEnabled;

            }

            set

            {

                AccountEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AssignedLicenses instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AssignedLicense> assignedLicenses

        {

            get

            {

                return AssignedLicenses;

            }

            set

            {

                AssignedLicenses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AssignedPlans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.AssignedPlan> assignedPlans

        {

            get

            {

                return AssignedPlans;

            }

            set

            {

                AssignedPlans = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BusinessPhones instead.")]

        public global::System.Collections.Generic.IList<System.String> businessPhones

        {

            get

            {

                return BusinessPhones;

            }

            set

            {

                BusinessPhones = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use City instead.")]

        public System.String city

        {

            get

            {

                return City;

            }

            set

            {

                City = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CompanyName instead.")]

        public System.String companyName

        {

            get

            {

                return CompanyName;

            }

            set

            {

                CompanyName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Country instead.")]

        public System.String country

        {

            get

            {

                return Country;

            }

            set

            {

                Country = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Department instead.")]

        public System.String department

        {

            get

            {

                return Department;

            }

            set

            {

                Department = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use GivenName instead.")]

        public System.String givenName

        {

            get

            {

                return GivenName;

            }

            set

            {

                GivenName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use JobTitle instead.")]

        public System.String jobTitle

        {

            get

            {

                return JobTitle;

            }

            set

            {

                JobTitle = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Mail instead.")]

        public System.String mail

        {

            get

            {

                return Mail;

            }

            set

            {

                Mail = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MailNickname instead.")]

        public System.String mailNickname

        {

            get

            {

                return MailNickname;

            }

            set

            {

                MailNickname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MobilePhone instead.")]

        public System.String mobilePhone

        {

            get

            {

                return MobilePhone;

            }

            set

            {

                MobilePhone = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesImmutableId instead.")]

        public System.String onPremisesImmutableId

        {

            get

            {

                return OnPremisesImmutableId;

            }

            set

            {

                OnPremisesImmutableId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesLastSyncDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> onPremisesLastSyncDateTime

        {

            get

            {

                return OnPremisesLastSyncDateTime;

            }

            set

            {

                OnPremisesLastSyncDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSecurityIdentifier instead.")]

        public System.String onPremisesSecurityIdentifier

        {

            get

            {

                return OnPremisesSecurityIdentifier;

            }

            set

            {

                OnPremisesSecurityIdentifier = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OnPremisesSyncEnabled instead.")]

        public System.Nullable<System.Boolean> onPremisesSyncEnabled

        {

            get

            {

                return OnPremisesSyncEnabled;

            }

            set

            {

                OnPremisesSyncEnabled = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PasswordPolicies instead.")]

        public System.String passwordPolicies

        {

            get

            {

                return PasswordPolicies;

            }

            set

            {

                PasswordPolicies = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PasswordProfile instead.")]

        public global::Microsoft.Graph.PasswordProfile passwordProfile

        {

            get

            {

                return PasswordProfile;

            }

            set

            {

                PasswordProfile = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OfficeLocation instead.")]

        public System.String officeLocation

        {

            get

            {

                return OfficeLocation;

            }

            set

            {

                OfficeLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PostalCode instead.")]

        public System.String postalCode

        {

            get

            {

                return PostalCode;

            }

            set

            {

                PostalCode = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PreferredLanguage instead.")]

        public System.String preferredLanguage

        {

            get

            {

                return PreferredLanguage;

            }

            set

            {

                PreferredLanguage = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProvisionedPlans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ProvisionedPlan> provisionedPlans

        {

            get

            {

                return ProvisionedPlans;

            }

            set

            {

                ProvisionedPlans = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ProxyAddresses instead.")]

        public global::System.Collections.Generic.IList<System.String> proxyAddresses

        {

            get

            {

                return ProxyAddresses;

            }

            set

            {

                ProxyAddresses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use State instead.")]

        public System.String state

        {

            get

            {

                return State;

            }

            set

            {

                State = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use StreetAddress instead.")]

        public System.String streetAddress

        {

            get

            {

                return StreetAddress;

            }

            set

            {

                StreetAddress = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Surname instead.")]

        public System.String surname

        {

            get

            {

                return Surname;

            }

            set

            {

                Surname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UsageLocation instead.")]

        public System.String usageLocation

        {

            get

            {

                return UsageLocation;

            }

            set

            {

                UsageLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UserPrincipalName instead.")]

        public System.String userPrincipalName

        {

            get

            {

                return UserPrincipalName;

            }

            set

            {

                UserPrincipalName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UserType instead.")]

        public System.String userType

        {

            get

            {

                return UserType;

            }

            set

            {

                UserType = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AboutMe instead.")]

        public System.String aboutMe

        {

            get

            {

                return AboutMe;

            }

            set

            {

                AboutMe = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Birthday instead.")]

        public System.DateTimeOffset birthday

        {

            get

            {

                return Birthday;

            }

            set

            {

                Birthday = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HireDate instead.")]

        public System.DateTimeOffset hireDate

        {

            get

            {

                return HireDate;

            }

            set

            {

                HireDate = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Interests instead.")]

        public global::System.Collections.Generic.IList<System.String> interests

        {

            get

            {

                return Interests;

            }

            set

            {

                Interests = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MySite instead.")]

        public System.String mySite

        {

            get

            {

                return MySite;

            }

            set

            {

                MySite = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PastProjects instead.")]

        public global::System.Collections.Generic.IList<System.String> pastProjects

        {

            get

            {

                return PastProjects;

            }

            set

            {

                PastProjects = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PreferredName instead.")]

        public System.String preferredName

        {

            get

            {

                return PreferredName;

            }

            set

            {

                PreferredName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Responsibilities instead.")]

        public global::System.Collections.Generic.IList<System.String> responsibilities

        {

            get

            {

                return Responsibilities;

            }

            set

            {

                Responsibilities = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Schools instead.")]

        public global::System.Collections.Generic.IList<System.String> schools

        {

            get

            {

                return Schools;

            }

            set

            {

                Schools = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Skills instead.")]

        public global::System.Collections.Generic.IList<System.String> skills

        {

            get

            {

                return Skills;

            }

            set

            {

                Skills = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OwnedDevices instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> ownedDevices

        {

            get

            {

                return OwnedDevices;

            }

            set

            {

                OwnedDevices = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use RegisteredDevices instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> registeredDevices

        {

            get

            {

                return RegisteredDevices;

            }

            set

            {

                RegisteredDevices = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Manager instead.")]

        public global::Microsoft.Graph.DirectoryObject manager

        {

            get

            {

                return Manager;

            }

            set

            {

                Manager = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DirectReports instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> directReports

        {

            get

            {

                return DirectReports;

            }

            set

            {

                DirectReports = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MemberOf instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> memberOf

        {

            get

            {

                return MemberOf;

            }

            set

            {

                MemberOf = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CreatedObjects instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> createdObjects

        {

            get

            {

                return CreatedObjects;

            }

            set

            {

                CreatedObjects = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OwnedObjects instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> ownedObjects

        {

            get

            {

                return OwnedObjects;

            }

            set

            {

                OwnedObjects = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Messages instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Message> messages

        {

            get

            {

                return Messages;

            }

            set

            {

                Messages = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use JoinedGroups instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Group> joinedGroups

        {

            get

            {

                return JoinedGroups;

            }

            set

            {

                JoinedGroups = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MailFolders instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.MailFolder> mailFolders

        {

            get

            {

                return MailFolders;

            }

            set

            {

                MailFolders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Calendar instead.")]

        public global::Microsoft.Graph.Calendar calendar

        {

            get

            {

                return Calendar;

            }

            set

            {

                Calendar = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Calendars instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Calendar> calendars

        {

            get

            {

                return Calendars;

            }

            set

            {

                Calendars = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CalendarGroups instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.CalendarGroup> calendarGroups

        {

            get

            {

                return CalendarGroups;

            }

            set

            {

                CalendarGroups = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CalendarView instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> calendarView

        {

            get

            {

                return CalendarView;

            }

            set

            {

                CalendarView = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Events instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> events

        {

            get

            {

                return Events;

            }

            set

            {

                Events = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use People instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Person> people

        {

            get

            {

                return People;

            }

            set

            {

                People = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Contacts instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Contact> contacts

        {

            get

            {

                return Contacts;

            }

            set

            {

                Contacts = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ContactFolders instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ContactFolder> contactFolders

        {

            get

            {

                return ContactFolders;

            }

            set

            {

                ContactFolders = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use InferenceClassification instead.")]

        public global::Microsoft.Graph.InferenceClassification inferenceClassification

        {

            get

            {

                return InferenceClassification;

            }

            set

            {

                InferenceClassification = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Photo instead.")]

        public global::Microsoft.Graph.ProfilePhoto photo

        {

            get

            {

                return Photo;

            }

            set

            {

                Photo = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Photos instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ProfilePhoto> photos

        {

            get

            {

                return Photos;

            }

            set

            {

                Photos = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Drive instead.")]

        public global::Microsoft.Graph.Drive drive

        {

            get

            {

                return Drive;

            }

            set

            {

                Drive = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Notes instead.")]

        public global::Microsoft.Graph.Notes notes

        {

            get

            {

                return Notes;

            }

            set

            {

                Notes = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Tasks instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Task> tasks

        {

            get

            {

                return Tasks;

            }

            set

            {

                Tasks = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Plans instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Plan> plans

        {

            get

            {

                return Plans;

            }

            set

            {

                Plans = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> OwnedDevices

        {

            get

            {

                if (this._ownedDevicesConcrete == null)

                {

                    this._ownedDevicesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._ownedDevicesConcrete.SetContainer(() => GetContainingEntity("ownedDevices"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._ownedDevicesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                OwnedDevices.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        OwnedDevices.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> RegisteredDevices

        {

            get

            {

                if (this._registeredDevicesConcrete == null)

                {

                    this._registeredDevicesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._registeredDevicesConcrete.SetContainer(() => GetContainingEntity("registeredDevices"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._registeredDevicesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                RegisteredDevices.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        RegisteredDevices.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.DirectoryObject Manager

        {

            get

            {

                return this._manager;

            }

            set

            {

                if (this._manager != value)

                {

                    this._manager = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "manager", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> DirectReports

        {

            get

            {

                if (this._directReportsConcrete == null)

                {

                    this._directReportsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._directReportsConcrete.SetContainer(() => GetContainingEntity("directReports"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._directReportsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                DirectReports.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        DirectReports.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> MemberOf

        {

            get

            {

                if (this._memberOfConcrete == null)

                {

                    this._memberOfConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._memberOfConcrete.SetContainer(() => GetContainingEntity("memberOf"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._memberOfConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                MemberOf.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        MemberOf.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> CreatedObjects

        {

            get

            {

                if (this._createdObjectsConcrete == null)

                {

                    this._createdObjectsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._createdObjectsConcrete.SetContainer(() => GetContainingEntity("createdObjects"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._createdObjectsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                CreatedObjects.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CreatedObjects.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject> OwnedObjects

        {

            get

            {

                if (this._ownedObjectsConcrete == null)

                {

                    this._ownedObjectsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DirectoryObject>();

                    this._ownedObjectsConcrete.SetContainer(() => GetContainingEntity("ownedObjects"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DirectoryObject>)this._ownedObjectsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                OwnedObjects.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        OwnedObjects.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Message> Messages

        {

            get

            {

                if (this._messagesConcrete == null)

                {

                    this._messagesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Message>();

                    this._messagesConcrete.SetContainer(() => GetContainingEntity("messages"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Message>)this._messagesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Messages.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Messages.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Group> JoinedGroups

        {

            get

            {

                if (this._joinedGroupsConcrete == null)

                {

                    this._joinedGroupsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Group>();

                    this._joinedGroupsConcrete.SetContainer(() => GetContainingEntity("joinedGroups"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Group>)this._joinedGroupsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                JoinedGroups.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        JoinedGroups.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.MailFolder> MailFolders

        {

            get

            {

                if (this._mailFoldersConcrete == null)

                {

                    this._mailFoldersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.MailFolder>();

                    this._mailFoldersConcrete.SetContainer(() => GetContainingEntity("mailFolders"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.MailFolder>)this._mailFoldersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                MailFolders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        MailFolders.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Calendar Calendar

        {

            get

            {

                return this._calendar;

            }

            set

            {

                if (this._calendar != value)

                {

                    this._calendar = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "calendar", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Calendar> Calendars

        {

            get

            {

                if (this._calendarsConcrete == null)

                {

                    this._calendarsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Calendar>();

                    this._calendarsConcrete.SetContainer(() => GetContainingEntity("calendars"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Calendar>)this._calendarsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Calendars.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Calendars.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.CalendarGroup> CalendarGroups

        {

            get

            {

                if (this._calendarGroupsConcrete == null)

                {

                    this._calendarGroupsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.CalendarGroup>();

                    this._calendarGroupsConcrete.SetContainer(() => GetContainingEntity("calendarGroups"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.CalendarGroup>)this._calendarGroupsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                CalendarGroups.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CalendarGroups.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> CalendarView

        {

            get

            {

                if (this._calendarViewConcrete == null)

                {

                    this._calendarViewConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._calendarViewConcrete.SetContainer(() => GetContainingEntity("calendarView"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._calendarViewConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                CalendarView.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CalendarView.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Event> Events

        {

            get

            {

                if (this._eventsConcrete == null)

                {

                    this._eventsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Event>();

                    this._eventsConcrete.SetContainer(() => GetContainingEntity("events"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Event>)this._eventsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Events.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Events.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Person> People

        {

            get

            {

                if (this._peopleConcrete == null)

                {

                    this._peopleConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Person>();

                    this._peopleConcrete.SetContainer(() => GetContainingEntity("people"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Person>)this._peopleConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                People.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        People.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Contact> Contacts

        {

            get

            {

                if (this._contactsConcrete == null)

                {

                    this._contactsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Contact>();

                    this._contactsConcrete.SetContainer(() => GetContainingEntity("contacts"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Contact>)this._contactsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Contacts.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Contacts.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ContactFolder> ContactFolders

        {

            get

            {

                if (this._contactFoldersConcrete == null)

                {

                    this._contactFoldersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ContactFolder>();

                    this._contactFoldersConcrete.SetContainer(() => GetContainingEntity("contactFolders"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.ContactFolder>)this._contactFoldersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                ContactFolders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ContactFolders.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.InferenceClassification InferenceClassification

        {

            get

            {

                return this._inferenceClassification;

            }

            set

            {

                if (this._inferenceClassification != value)

                {

                    this._inferenceClassification = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "inferenceClassification", value);

                    }

                }

            }

        }

        public global::Microsoft.Graph.ProfilePhoto Photo

        {

            get

            {

                return this._photo;

            }

            set

            {

                if (this._photo != value)

                {

                    this._photo = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "photo", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.ProfilePhoto> Photos

        {

            get

            {

                if (this._photosConcrete == null)

                {

                    this._photosConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.ProfilePhoto>();

                    this._photosConcrete.SetContainer(() => GetContainingEntity("photos"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.ProfilePhoto>)this._photosConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Photos.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Photos.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Drive Drive

        {

            get

            {

                return this._drive;

            }

            set

            {

                if (this._drive != value)

                {

                    this._drive = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "drive", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem> TrendingAround

        {

            get

            {

                if (this._TrendingAroundConcrete == null)

                {

                    this._TrendingAroundConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.DriveItem>();

                    this._TrendingAroundConcrete.SetContainer(() => GetContainingEntity("TrendingAround"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.DriveItem>)this._TrendingAroundConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                TrendingAround.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        TrendingAround.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.User> WorkingWith

        {

            get

            {

                if (this._WorkingWithConcrete == null)

                {

                    this._WorkingWithConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.User>();

                    this._WorkingWithConcrete.SetContainer(() => GetContainingEntity("WorkingWith"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.User>)this._WorkingWithConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                WorkingWith.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        WorkingWith.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.Notes Notes

        {

            get

            {

                return this._notes;

            }

            set

            {

                if (this._notes != value)

                {

                    this._notes = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "notes", value);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Task> Tasks

        {

            get

            {

                if (this._tasksConcrete == null)

                {

                    this._tasksConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Task>();

                    this._tasksConcrete.SetContainer(() => GetContainingEntity("tasks"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Task>)this._tasksConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Tasks.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Tasks.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Plan> Plans

        {

            get

            {

                if (this._plansConcrete == null)

                {

                    this._plansConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Plan>();

                    this._plansConcrete.SetContainer(() => GetContainingEntity("plans"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Plan>)this._plansConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Plans.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Plans.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IUserFetcher.OwnedDevices

        {

            get

            {

                if (this._ownedDevicesCollection == null)

                {

                    this._ownedDevicesCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("ownedDevices")) : null,
                       Context,
                       this,
                       GetPath("ownedDevices"));

                }



                return this._ownedDevicesCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IUserFetcher.RegisteredDevices

        {

            get

            {

                if (this._registeredDevicesCollection == null)

                {

                    this._registeredDevicesCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("registeredDevices")) : null,
                       Context,
                       this,
                       GetPath("registeredDevices"));

                }



                return this._registeredDevicesCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectFetcher global::Microsoft.Graph.IUserFetcher.Manager

        {

            get

            {

                if (this._managerFetcher == null)

                {

                    this._managerFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._managerFetcher.Initialize(this.Context, GetPath("manager"));

                }



                return this._managerFetcher;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IUserFetcher.DirectReports

        {

            get

            {

                if (this._directReportsCollection == null)

                {

                    this._directReportsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("directReports")) : null,
                       Context,
                       this,
                       GetPath("directReports"));

                }



                return this._directReportsCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IUserFetcher.MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IUserFetcher.CreatedObjects

        {

            get

            {

                if (this._createdObjectsCollection == null)

                {

                    this._createdObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("createdObjects")) : null,
                       Context,
                       this,
                       GetPath("createdObjects"));

                }



                return this._createdObjectsCollection;

            }

        }

        global::Microsoft.Graph.IDirectoryObjectCollection global::Microsoft.Graph.IUserFetcher.OwnedObjects

        {

            get

            {

                if (this._ownedObjectsCollection == null)

                {

                    this._ownedObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("ownedObjects")) : null,
                       Context,
                       this,
                       GetPath("ownedObjects"));

                }



                return this._ownedObjectsCollection;

            }

        }

        global::Microsoft.Graph.IMessageCollection global::Microsoft.Graph.IUserFetcher.Messages

        {

            get

            {

                if (this._messagesCollection == null)

                {

                    this._messagesCollection = new global::Microsoft.Graph.MessageCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Message>(GetPath("messages")) : null,
                       Context,
                       this,
                       GetPath("messages"));

                }



                return this._messagesCollection;

            }

        }

        global::Microsoft.Graph.IGroupCollection global::Microsoft.Graph.IUserFetcher.JoinedGroups

        {

            get

            {

                if (this._joinedGroupsCollection == null)

                {

                    this._joinedGroupsCollection = new global::Microsoft.Graph.GroupCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Group>(GetPath("joinedGroups")) : null,
                       Context,
                       this,
                       GetPath("joinedGroups"));

                }



                return this._joinedGroupsCollection;

            }

        }

        global::Microsoft.Graph.IMailFolderCollection global::Microsoft.Graph.IUserFetcher.MailFolders

        {

            get

            {

                if (this._mailFoldersCollection == null)

                {

                    this._mailFoldersCollection = new global::Microsoft.Graph.MailFolderCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.MailFolder>(GetPath("mailFolders")) : null,
                       Context,
                       this,
                       GetPath("mailFolders"));

                }



                return this._mailFoldersCollection;

            }

        }

        global::Microsoft.Graph.ICalendarFetcher global::Microsoft.Graph.IUserFetcher.Calendar

        {

            get

            {

                if (this._calendarFetcher == null)

                {

                    this._calendarFetcher = new global::Microsoft.Graph.CalendarFetcher();

                    this._calendarFetcher.Initialize(this.Context, GetPath("calendar"));

                }



                return this._calendarFetcher;

            }

        }

        global::Microsoft.Graph.ICalendarCollection global::Microsoft.Graph.IUserFetcher.Calendars

        {

            get

            {

                if (this._calendarsCollection == null)

                {

                    this._calendarsCollection = new global::Microsoft.Graph.CalendarCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Calendar>(GetPath("calendars")) : null,
                       Context,
                       this,
                       GetPath("calendars"));

                }



                return this._calendarsCollection;

            }

        }

        global::Microsoft.Graph.ICalendarGroupCollection global::Microsoft.Graph.IUserFetcher.CalendarGroups

        {

            get

            {

                if (this._calendarGroupsCollection == null)

                {

                    this._calendarGroupsCollection = new global::Microsoft.Graph.CalendarGroupCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.CalendarGroup>(GetPath("calendarGroups")) : null,
                       Context,
                       this,
                       GetPath("calendarGroups"));

                }



                return this._calendarGroupsCollection;

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.IUserFetcher.CalendarView

        {

            get

            {

                if (this._calendarViewCollection == null)

                {

                    this._calendarViewCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("calendarView")) : null,
                       Context,
                       this,
                       GetPath("calendarView"));

                }



                return this._calendarViewCollection;

            }

        }

        global::Microsoft.Graph.IEventCollection global::Microsoft.Graph.IUserFetcher.Events

        {

            get

            {

                if (this._eventsCollection == null)

                {

                    this._eventsCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("events")) : null,
                       Context,
                       this,
                       GetPath("events"));

                }



                return this._eventsCollection;

            }

        }

        global::Microsoft.Graph.IPersonCollection global::Microsoft.Graph.IUserFetcher.People

        {

            get

            {

                if (this._peopleCollection == null)

                {

                    this._peopleCollection = new global::Microsoft.Graph.PersonCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Person>(GetPath("people")) : null,
                       Context,
                       this,
                       GetPath("people"));

                }



                return this._peopleCollection;

            }

        }

        global::Microsoft.Graph.IContactCollection global::Microsoft.Graph.IUserFetcher.Contacts

        {

            get

            {

                if (this._contactsCollection == null)

                {

                    this._contactsCollection = new global::Microsoft.Graph.ContactCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Contact>(GetPath("contacts")) : null,
                       Context,
                       this,
                       GetPath("contacts"));

                }



                return this._contactsCollection;

            }

        }

        global::Microsoft.Graph.IContactFolderCollection global::Microsoft.Graph.IUserFetcher.ContactFolders

        {

            get

            {

                if (this._contactFoldersCollection == null)

                {

                    this._contactFoldersCollection = new global::Microsoft.Graph.ContactFolderCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ContactFolder>(GetPath("contactFolders")) : null,
                       Context,
                       this,
                       GetPath("contactFolders"));

                }



                return this._contactFoldersCollection;

            }

        }

        global::Microsoft.Graph.IInferenceClassificationFetcher global::Microsoft.Graph.IUserFetcher.InferenceClassification

        {

            get

            {

                if (this._inferenceClassificationFetcher == null)

                {

                    this._inferenceClassificationFetcher = new global::Microsoft.Graph.InferenceClassificationFetcher();

                    this._inferenceClassificationFetcher.Initialize(this.Context, GetPath("inferenceClassification"));

                }



                return this._inferenceClassificationFetcher;

            }

        }

        global::Microsoft.Graph.IProfilePhotoFetcher global::Microsoft.Graph.IUserFetcher.Photo

        {

            get

            {

                if (this._photoFetcher == null)

                {

                    this._photoFetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                    this._photoFetcher.Initialize(this.Context, GetPath("photo"));

                }



                return this._photoFetcher;

            }

        }

        global::Microsoft.Graph.IProfilePhotoCollection global::Microsoft.Graph.IUserFetcher.Photos

        {

            get

            {

                if (this._photosCollection == null)

                {

                    this._photosCollection = new global::Microsoft.Graph.ProfilePhotoCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ProfilePhoto>(GetPath("photos")) : null,
                       Context,
                       this,
                       GetPath("photos"));

                }



                return this._photosCollection;

            }

        }

        global::Microsoft.Graph.IDriveFetcher global::Microsoft.Graph.IUserFetcher.Drive

        {

            get

            {

                if (this._driveFetcher == null)

                {

                    this._driveFetcher = new global::Microsoft.Graph.DriveFetcher();

                    this._driveFetcher.Initialize(this.Context, GetPath("drive"));

                }



                return this._driveFetcher;

            }

        }

        global::Microsoft.Graph.IDriveItemCollection global::Microsoft.Graph.IUserFetcher.TrendingAround

        {

            get

            {

                if (this._TrendingAroundCollection == null)

                {

                    this._TrendingAroundCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("TrendingAround")) : null,
                       Context,
                       this,
                       GetPath("TrendingAround"));

                }



                return this._TrendingAroundCollection;

            }

        }

        global::Microsoft.Graph.IUserCollection global::Microsoft.Graph.IUserFetcher.WorkingWith

        {

            get

            {

                if (this._WorkingWithCollection == null)

                {

                    this._WorkingWithCollection = new global::Microsoft.Graph.UserCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.User>(GetPath("WorkingWith")) : null,
                       Context,
                       this,
                       GetPath("WorkingWith"));

                }



                return this._WorkingWithCollection;

            }

        }

        global::Microsoft.Graph.INotesFetcher global::Microsoft.Graph.IUserFetcher.Notes

        {

            get

            {

                if (this._notesFetcher == null)

                {

                    this._notesFetcher = new global::Microsoft.Graph.NotesFetcher();

                    this._notesFetcher.Initialize(this.Context, GetPath("notes"));

                }



                return this._notesFetcher;

            }

        }

        global::Microsoft.Graph.ITaskCollection global::Microsoft.Graph.IUserFetcher.Tasks

        {

            get

            {

                if (this._tasksCollection == null)

                {

                    this._tasksCollection = new global::Microsoft.Graph.TaskCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Task>(GetPath("tasks")) : null,
                       Context,
                       this,
                       GetPath("tasks"));

                }



                return this._tasksCollection;

            }

        }

        global::Microsoft.Graph.IPlanCollection global::Microsoft.Graph.IUserFetcher.Plans

        {

            get

            {

                if (this._plansCollection == null)

                {

                    this._plansCollection = new global::Microsoft.Graph.PlanCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Plan>(GetPath("plans")) : null,
                       Context,
                       this,
                       GetPath("plans"));

                }



                return this._plansCollection;

            }

        }

        public User()

        {

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IUser> assignLicenseAsync(System.Collections.Generic.ICollection<global::Microsoft.Graph.AssignedLicense> addLicenses, System.Collections.Generic.ICollection<System.Guid> removeLicenses)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/assignLicense");

            return (global::Microsoft.Graph.IUser)Enumerable.Single<global::Microsoft.Graph.User>(await this.Context.ExecuteAsync<global::Microsoft.Graph.User>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("addLicenses", (object) addLicenses),

                new BodyOperationParameter("removeLicenses", (object) removeLicenses),

            }

            ));

        }

        public async System.Threading.Tasks.Task changePasswordAsync(System.String currentPassword, System.String newPassword)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/changePassword");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("currentPassword", (object) currentPassword),

                new BodyOperationParameter("newPassword", (object) newPassword),

            }

            );

        }

        public async System.Threading.Tasks.Task sendMailAsync(global::Microsoft.Graph.IMessage Message, System.Nullable<System.Boolean> SaveToSentItems)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/sendMail");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Message", (object) Message),

                new BodyOperationParameter("SaveToSentItems", (object) SaveToSentItems),

            }

            );

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.MeetingTimeCandidate> findMeetingTimesAsync(System.Collections.Generic.ICollection<global::Microsoft.Graph.AttendeeBase> Attendees, global::Microsoft.Graph.LocationConstraint LocationConstraint, global::Microsoft.Graph.TimeConstraint TimeConstraint, System.Nullable<System.TimeSpan> MeetingDuration, System.Nullable<System.Int32> MaxCandidates, System.Nullable<System.Boolean> IsOrganizerOptional)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/findMeetingTimes");

            return (global::Microsoft.Graph.MeetingTimeCandidate)Enumerable.Single<global::Microsoft.Graph.MeetingTimeCandidate>(await this.Context.ExecuteAsync<global::Microsoft.Graph.MeetingTimeCandidate>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("Attendees", (object) Attendees),

                new BodyOperationParameter("LocationConstraint", (object) LocationConstraint),

                new BodyOperationParameter("TimeConstraint", (object) TimeConstraint),

                new BodyOperationParameter("MeetingDuration", (object) MeetingDuration),

                new BodyOperationParameter("MaxCandidates", (object) MaxCandidates),

                new BodyOperationParameter("IsOrganizerOptional", (object) IsOrganizerOptional),

            }

            ));

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<global::Microsoft.Graph.Reminder>> reminderViewAsync(System.String StartDateTime, System.String EndDateTime)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/reminderView");

            return (await this.Context.ExecuteAsync<global::Microsoft.Graph.Reminder>(requestUri, "GET", false, new OperationParameter[]

            {

                new UriOperationParameter("StartDateTime", (object) StartDateTime),

                new UriOperationParameter("EndDateTime", (object) EndDateTime),

            }

            ));

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IUser> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.User, global::Microsoft.Graph.IUser>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IUser> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IUser> global::Microsoft.Graph.IUserFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IUser>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IUserFetcher global::Microsoft.Graph.IUserFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IUser, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IUserFetcher)this;

        }

    }

    internal partial class UserFetcher : global::Microsoft.Graph.DirectoryObjectFetcher, global::Microsoft.Graph.IUserFetcher

    {

        private global::Microsoft.Graph.DirectoryObjectFetcher _managerFetcher;

        private global::Microsoft.Graph.CalendarFetcher _calendarFetcher;

        private global::Microsoft.Graph.InferenceClassificationFetcher _inferenceClassificationFetcher;

        private global::Microsoft.Graph.ProfilePhotoFetcher _photoFetcher;

        private global::Microsoft.Graph.DriveFetcher _driveFetcher;

        private global::Microsoft.Graph.NotesFetcher _notesFetcher;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownedDevicesCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _registeredDevicesCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _directReportsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _memberOfCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _createdObjectsCollection;

        private global::Microsoft.Graph.DirectoryObjectCollection _ownedObjectsCollection;

        private global::Microsoft.Graph.MessageCollection _messagesCollection;

        private global::Microsoft.Graph.GroupCollection _joinedGroupsCollection;

        private global::Microsoft.Graph.MailFolderCollection _mailFoldersCollection;

        private global::Microsoft.Graph.CalendarCollection _calendarsCollection;

        private global::Microsoft.Graph.CalendarGroupCollection _calendarGroupsCollection;

        private global::Microsoft.Graph.EventCollection _calendarViewCollection;

        private global::Microsoft.Graph.EventCollection _eventsCollection;

        private global::Microsoft.Graph.PersonCollection _peopleCollection;

        private global::Microsoft.Graph.ContactCollection _contactsCollection;

        private global::Microsoft.Graph.ContactFolderCollection _contactFoldersCollection;

        private global::Microsoft.Graph.ProfilePhotoCollection _photosCollection;

        private global::Microsoft.Graph.DriveItemCollection _TrendingAroundCollection;

        private global::Microsoft.Graph.UserCollection _WorkingWithCollection;

        private global::Microsoft.Graph.TaskCollection _tasksCollection;

        private global::Microsoft.Graph.PlanCollection _plansCollection;

        public global::Microsoft.Graph.IDirectoryObjectCollection OwnedDevices

        {

            get

            {

                if (this._ownedDevicesCollection == null)

                {

                    this._ownedDevicesCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("ownedDevices")) : null,
                       Context,
                       this,
                       GetPath("ownedDevices"));

                }



                return this._ownedDevicesCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection RegisteredDevices

        {

            get

            {

                if (this._registeredDevicesCollection == null)

                {

                    this._registeredDevicesCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("registeredDevices")) : null,
                       Context,
                       this,
                       GetPath("registeredDevices"));

                }



                return this._registeredDevicesCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectFetcher Manager

        {

            get

            {

                if (this._managerFetcher == null)

                {

                    this._managerFetcher = new global::Microsoft.Graph.DirectoryObjectFetcher();

                    this._managerFetcher.Initialize(this.Context, GetPath("manager"));

                }



                return this._managerFetcher;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection DirectReports

        {

            get

            {

                if (this._directReportsCollection == null)

                {

                    this._directReportsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("directReports")) : null,
                       Context,
                       this,
                       GetPath("directReports"));

                }



                return this._directReportsCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection MemberOf

        {

            get

            {

                if (this._memberOfCollection == null)

                {

                    this._memberOfCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("memberOf")) : null,
                       Context,
                       this,
                       GetPath("memberOf"));

                }



                return this._memberOfCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection CreatedObjects

        {

            get

            {

                if (this._createdObjectsCollection == null)

                {

                    this._createdObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("createdObjects")) : null,
                       Context,
                       this,
                       GetPath("createdObjects"));

                }



                return this._createdObjectsCollection;

            }

        }

        public global::Microsoft.Graph.IDirectoryObjectCollection OwnedObjects

        {

            get

            {

                if (this._ownedObjectsCollection == null)

                {

                    this._ownedObjectsCollection = new global::Microsoft.Graph.DirectoryObjectCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DirectoryObject>(GetPath("ownedObjects")) : null,
                       Context,
                       this,
                       GetPath("ownedObjects"));

                }



                return this._ownedObjectsCollection;

            }

        }

        public global::Microsoft.Graph.IMessageCollection Messages

        {

            get

            {

                if (this._messagesCollection == null)

                {

                    this._messagesCollection = new global::Microsoft.Graph.MessageCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Message>(GetPath("messages")) : null,
                       Context,
                       this,
                       GetPath("messages"));

                }



                return this._messagesCollection;

            }

        }

        public global::Microsoft.Graph.IGroupCollection JoinedGroups

        {

            get

            {

                if (this._joinedGroupsCollection == null)

                {

                    this._joinedGroupsCollection = new global::Microsoft.Graph.GroupCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Group>(GetPath("joinedGroups")) : null,
                       Context,
                       this,
                       GetPath("joinedGroups"));

                }



                return this._joinedGroupsCollection;

            }

        }

        public global::Microsoft.Graph.IMailFolderCollection MailFolders

        {

            get

            {

                if (this._mailFoldersCollection == null)

                {

                    this._mailFoldersCollection = new global::Microsoft.Graph.MailFolderCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.MailFolder>(GetPath("mailFolders")) : null,
                       Context,
                       this,
                       GetPath("mailFolders"));

                }



                return this._mailFoldersCollection;

            }

        }

        public global::Microsoft.Graph.ICalendarFetcher Calendar

        {

            get

            {

                if (this._calendarFetcher == null)

                {

                    this._calendarFetcher = new global::Microsoft.Graph.CalendarFetcher();

                    this._calendarFetcher.Initialize(this.Context, GetPath("calendar"));

                }



                return this._calendarFetcher;

            }

        }

        public global::Microsoft.Graph.ICalendarCollection Calendars

        {

            get

            {

                if (this._calendarsCollection == null)

                {

                    this._calendarsCollection = new global::Microsoft.Graph.CalendarCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Calendar>(GetPath("calendars")) : null,
                       Context,
                       this,
                       GetPath("calendars"));

                }



                return this._calendarsCollection;

            }

        }

        public global::Microsoft.Graph.ICalendarGroupCollection CalendarGroups

        {

            get

            {

                if (this._calendarGroupsCollection == null)

                {

                    this._calendarGroupsCollection = new global::Microsoft.Graph.CalendarGroupCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.CalendarGroup>(GetPath("calendarGroups")) : null,
                       Context,
                       this,
                       GetPath("calendarGroups"));

                }



                return this._calendarGroupsCollection;

            }

        }

        public global::Microsoft.Graph.IEventCollection CalendarView

        {

            get

            {

                if (this._calendarViewCollection == null)

                {

                    this._calendarViewCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("calendarView")) : null,
                       Context,
                       this,
                       GetPath("calendarView"));

                }



                return this._calendarViewCollection;

            }

        }

        public global::Microsoft.Graph.IEventCollection Events

        {

            get

            {

                if (this._eventsCollection == null)

                {

                    this._eventsCollection = new global::Microsoft.Graph.EventCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Event>(GetPath("events")) : null,
                       Context,
                       this,
                       GetPath("events"));

                }



                return this._eventsCollection;

            }

        }

        public global::Microsoft.Graph.IPersonCollection People

        {

            get

            {

                if (this._peopleCollection == null)

                {

                    this._peopleCollection = new global::Microsoft.Graph.PersonCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Person>(GetPath("people")) : null,
                       Context,
                       this,
                       GetPath("people"));

                }



                return this._peopleCollection;

            }

        }

        public global::Microsoft.Graph.IContactCollection Contacts

        {

            get

            {

                if (this._contactsCollection == null)

                {

                    this._contactsCollection = new global::Microsoft.Graph.ContactCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Contact>(GetPath("contacts")) : null,
                       Context,
                       this,
                       GetPath("contacts"));

                }



                return this._contactsCollection;

            }

        }

        public global::Microsoft.Graph.IContactFolderCollection ContactFolders

        {

            get

            {

                if (this._contactFoldersCollection == null)

                {

                    this._contactFoldersCollection = new global::Microsoft.Graph.ContactFolderCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ContactFolder>(GetPath("contactFolders")) : null,
                       Context,
                       this,
                       GetPath("contactFolders"));

                }



                return this._contactFoldersCollection;

            }

        }

        public global::Microsoft.Graph.IInferenceClassificationFetcher InferenceClassification

        {

            get

            {

                if (this._inferenceClassificationFetcher == null)

                {

                    this._inferenceClassificationFetcher = new global::Microsoft.Graph.InferenceClassificationFetcher();

                    this._inferenceClassificationFetcher.Initialize(this.Context, GetPath("inferenceClassification"));

                }



                return this._inferenceClassificationFetcher;

            }

        }

        public global::Microsoft.Graph.IProfilePhotoFetcher Photo

        {

            get

            {

                if (this._photoFetcher == null)

                {

                    this._photoFetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                    this._photoFetcher.Initialize(this.Context, GetPath("photo"));

                }



                return this._photoFetcher;

            }

        }

        public global::Microsoft.Graph.IProfilePhotoCollection Photos

        {

            get

            {

                if (this._photosCollection == null)

                {

                    this._photosCollection = new global::Microsoft.Graph.ProfilePhotoCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.ProfilePhoto>(GetPath("photos")) : null,
                       Context,
                       this,
                       GetPath("photos"));

                }



                return this._photosCollection;

            }

        }

        public global::Microsoft.Graph.IDriveFetcher Drive

        {

            get

            {

                if (this._driveFetcher == null)

                {

                    this._driveFetcher = new global::Microsoft.Graph.DriveFetcher();

                    this._driveFetcher.Initialize(this.Context, GetPath("drive"));

                }



                return this._driveFetcher;

            }

        }

        public global::Microsoft.Graph.IDriveItemCollection TrendingAround

        {

            get

            {

                if (this._TrendingAroundCollection == null)

                {

                    this._TrendingAroundCollection = new global::Microsoft.Graph.DriveItemCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.DriveItem>(GetPath("TrendingAround")) : null,
                       Context,
                       this,
                       GetPath("TrendingAround"));

                }



                return this._TrendingAroundCollection;

            }

        }

        public global::Microsoft.Graph.IUserCollection WorkingWith

        {

            get

            {

                if (this._WorkingWithCollection == null)

                {

                    this._WorkingWithCollection = new global::Microsoft.Graph.UserCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.User>(GetPath("WorkingWith")) : null,
                       Context,
                       this,
                       GetPath("WorkingWith"));

                }



                return this._WorkingWithCollection;

            }

        }

        public global::Microsoft.Graph.INotesFetcher Notes

        {

            get

            {

                if (this._notesFetcher == null)

                {

                    this._notesFetcher = new global::Microsoft.Graph.NotesFetcher();

                    this._notesFetcher.Initialize(this.Context, GetPath("notes"));

                }



                return this._notesFetcher;

            }

        }

        public global::Microsoft.Graph.ITaskCollection Tasks

        {

            get

            {

                if (this._tasksCollection == null)

                {

                    this._tasksCollection = new global::Microsoft.Graph.TaskCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Task>(GetPath("tasks")) : null,
                       Context,
                       this,
                       GetPath("tasks"));

                }



                return this._tasksCollection;

            }

        }

        public global::Microsoft.Graph.IPlanCollection Plans

        {

            get

            {

                if (this._plansCollection == null)

                {

                    this._plansCollection = new global::Microsoft.Graph.PlanCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Plan>(GetPath("plans")) : null,
                       Context,
                       this,
                       GetPath("plans"));

                }



                return this._plansCollection;

            }

        }

        public UserFetcher()

        {

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IUser> assignLicenseAsync(System.Collections.Generic.ICollection<global::Microsoft.Graph.AssignedLicense> addLicenses, System.Collections.Generic.ICollection<System.Guid> removeLicenses)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/assignLicense");

            return (global::Microsoft.Graph.IUser)Enumerable.Single<global::Microsoft.Graph.User>(await this.Context.ExecuteAsync<global::Microsoft.Graph.User>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("addLicenses", (object) addLicenses),

                new BodyOperationParameter("removeLicenses", (object) removeLicenses),

            }

            ));

        }

        public async System.Threading.Tasks.Task changePasswordAsync(System.String currentPassword, System.String newPassword)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/changePassword");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("currentPassword", (object) currentPassword),

                new BodyOperationParameter("newPassword", (object) newPassword),

            }

            );

        }

        public async System.Threading.Tasks.Task sendMailAsync(global::Microsoft.Graph.IMessage Message, System.Nullable<System.Boolean> SaveToSentItems)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/sendMail");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Message", (object) Message),

                new BodyOperationParameter("SaveToSentItems", (object) SaveToSentItems),

            }

            );

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.MeetingTimeCandidate> findMeetingTimesAsync(System.Collections.Generic.ICollection<global::Microsoft.Graph.AttendeeBase> Attendees, global::Microsoft.Graph.LocationConstraint LocationConstraint, global::Microsoft.Graph.TimeConstraint TimeConstraint, System.Nullable<System.TimeSpan> MeetingDuration, System.Nullable<System.Int32> MaxCandidates, System.Nullable<System.Boolean> IsOrganizerOptional)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/findMeetingTimes");

            return (global::Microsoft.Graph.MeetingTimeCandidate)Enumerable.Single<global::Microsoft.Graph.MeetingTimeCandidate>(await this.Context.ExecuteAsync<global::Microsoft.Graph.MeetingTimeCandidate>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("Attendees", (object) Attendees),

                new BodyOperationParameter("LocationConstraint", (object) LocationConstraint),

                new BodyOperationParameter("TimeConstraint", (object) TimeConstraint),

                new BodyOperationParameter("MeetingDuration", (object) MeetingDuration),

                new BodyOperationParameter("MaxCandidates", (object) MaxCandidates),

                new BodyOperationParameter("IsOrganizerOptional", (object) IsOrganizerOptional),

            }

            ));

        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<global::Microsoft.Graph.Reminder>> reminderViewAsync(System.String StartDateTime, System.String EndDateTime)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/reminderView");

            return (await this.Context.ExecuteAsync<global::Microsoft.Graph.Reminder>(requestUri, "GET", false, new OperationParameter[]

            {

                new UriOperationParameter("StartDateTime", (object) StartDateTime),

                new UriOperationParameter("EndDateTime", (object) EndDateTime),

            }

            ));

        }

        public async new global::System.Threading.Tasks.Task<global::Microsoft.Graph.IUser> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IUserFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IUser, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IUserFetcher)new global::Microsoft.Graph.UserFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IUser> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.User, global::Microsoft.Graph.IUser>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IUser> _query;

    }

    internal partial class UserCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IUser>, global::Microsoft.Graph.IUserCollection

    {

        internal UserCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IUserFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IUser>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AdduserAsync(global::Microsoft.Graph.IUser item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IUserFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.User>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.UserFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class UserCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Message : global::Microsoft.Graph.OutlookItem, global::Microsoft.Graph.IMessage, global::Microsoft.Graph.IMessageFetcher

    {

        private global::Microsoft.Graph.ExtensionCollection _extensionsCollection;

        private global::Microsoft.Graph.AttachmentCollection _attachmentsCollection;

        private System.Nullable<System.DateTimeOffset> _receivedDateTime;

        private System.Nullable<System.DateTimeOffset> _sentDateTime;

        private System.Nullable<System.Boolean> _hasAttachments;

        private System.String _subject;

        private global::Microsoft.Graph.ItemBody _body;

        private System.String _bodyPreview;

        private global::Microsoft.Graph.Importance _importance;

        private System.String _parentFolderId;

        private global::Microsoft.Graph.Recipient _sender;

        private global::Microsoft.Graph.Recipient _from;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient> _toRecipients;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient> _ccRecipients;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient> _bccRecipients;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient> _replyTo;

        private System.String _conversationId;

        private global::Microsoft.Graph.ItemBody _uniqueBody;

        private System.Nullable<System.Boolean> _isDeliveryReceiptRequested;

        private System.Nullable<System.Boolean> _isReadReceiptRequested;

        private System.Nullable<System.Boolean> _isRead;

        private System.Nullable<System.Boolean> _isDraft;

        private System.String _webLink;

        private global::Microsoft.Graph.InferenceClassificationType _inferenceClassification;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Extension> _extensionsConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Attachment> _attachmentsConcrete;

        public System.Nullable<System.DateTimeOffset> ReceivedDateTime

        {

            get

            {

                return _receivedDateTime;

            }

            set

            {

                if (value != _receivedDateTime)

                {

                    _receivedDateTime = value;

                    OnPropertyChanged("receivedDateTime");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> SentDateTime

        {

            get

            {

                return _sentDateTime;

            }

            set

            {

                if (value != _sentDateTime)

                {

                    _sentDateTime = value;

                    OnPropertyChanged("sentDateTime");

                }

            }

        }

        public System.Nullable<System.Boolean> HasAttachments

        {

            get

            {

                return _hasAttachments;

            }

            set

            {

                if (value != _hasAttachments)

                {

                    _hasAttachments = value;

                    OnPropertyChanged("hasAttachments");

                }

            }

        }

        public System.String Subject

        {

            get

            {

                return _subject;

            }

            set

            {

                if (value != _subject)

                {

                    _subject = value;

                    OnPropertyChanged("subject");

                }

            }

        }

        public global::Microsoft.Graph.ItemBody Body

        {

            get

            {

                return _body;

            }

            set

            {

                if (value != _body)

                {

                    _body = value;

                    OnPropertyChanged("body");

                }

            }

        }

        public System.String BodyPreview

        {

            get

            {

                return _bodyPreview;

            }

            set

            {

                if (value != _bodyPreview)

                {

                    _bodyPreview = value;

                    OnPropertyChanged("bodyPreview");

                }

            }

        }

        public global::Microsoft.Graph.Importance Importance

        {

            get

            {

                return _importance;

            }

            set

            {

                if (value != _importance)

                {

                    _importance = value;

                    OnPropertyChanged("importance");

                }

            }

        }

        public System.String ParentFolderId

        {

            get

            {

                return _parentFolderId;

            }

            set

            {

                if (value != _parentFolderId)

                {

                    _parentFolderId = value;

                    OnPropertyChanged("parentFolderId");

                }

            }

        }

        public global::Microsoft.Graph.Recipient Sender

        {

            get

            {

                return _sender;

            }

            set

            {

                if (value != _sender)

                {

                    _sender = value;

                    OnPropertyChanged("sender");

                }

            }

        }

        public global::Microsoft.Graph.Recipient From

        {

            get

            {

                return _from;

            }

            set

            {

                if (value != _from)

                {

                    _from = value;

                    OnPropertyChanged("from");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> ToRecipients

        {

            get

            {

                if (this._toRecipients == default(System.Collections.Generic.IList<global::Microsoft.Graph.Recipient>))

                {

                    this._toRecipients = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient>();

                    this._toRecipients.SetContainer(() => GetContainingEntity("toRecipients"));

                }

                return this._toRecipients;

            }

            set

            {

                ToRecipients.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ToRecipients.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> CcRecipients

        {

            get

            {

                if (this._ccRecipients == default(System.Collections.Generic.IList<global::Microsoft.Graph.Recipient>))

                {

                    this._ccRecipients = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient>();

                    this._ccRecipients.SetContainer(() => GetContainingEntity("ccRecipients"));

                }

                return this._ccRecipients;

            }

            set

            {

                CcRecipients.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        CcRecipients.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> BccRecipients

        {

            get

            {

                if (this._bccRecipients == default(System.Collections.Generic.IList<global::Microsoft.Graph.Recipient>))

                {

                    this._bccRecipients = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient>();

                    this._bccRecipients.SetContainer(() => GetContainingEntity("bccRecipients"));

                }

                return this._bccRecipients;

            }

            set

            {

                BccRecipients.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        BccRecipients.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> ReplyTo

        {

            get

            {

                if (this._replyTo == default(System.Collections.Generic.IList<global::Microsoft.Graph.Recipient>))

                {

                    this._replyTo = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Recipient>();

                    this._replyTo.SetContainer(() => GetContainingEntity("replyTo"));

                }

                return this._replyTo;

            }

            set

            {

                ReplyTo.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ReplyTo.Add(i);

                    }

                }

            }

        }

        public System.String ConversationId

        {

            get

            {

                return _conversationId;

            }

            set

            {

                if (value != _conversationId)

                {

                    _conversationId = value;

                    OnPropertyChanged("conversationId");

                }

            }

        }

        public global::Microsoft.Graph.ItemBody UniqueBody

        {

            get

            {

                return _uniqueBody;

            }

            set

            {

                if (value != _uniqueBody)

                {

                    _uniqueBody = value;

                    OnPropertyChanged("uniqueBody");

                }

            }

        }

        public System.Nullable<System.Boolean> IsDeliveryReceiptRequested

        {

            get

            {

                return _isDeliveryReceiptRequested;

            }

            set

            {

                if (value != _isDeliveryReceiptRequested)

                {

                    _isDeliveryReceiptRequested = value;

                    OnPropertyChanged("isDeliveryReceiptRequested");

                }

            }

        }

        public System.Nullable<System.Boolean> IsReadReceiptRequested

        {

            get

            {

                return _isReadReceiptRequested;

            }

            set

            {

                if (value != _isReadReceiptRequested)

                {

                    _isReadReceiptRequested = value;

                    OnPropertyChanged("isReadReceiptRequested");

                }

            }

        }

        public System.Nullable<System.Boolean> IsRead

        {

            get

            {

                return _isRead;

            }

            set

            {

                if (value != _isRead)

                {

                    _isRead = value;

                    OnPropertyChanged("isRead");

                }

            }

        }

        public System.Nullable<System.Boolean> IsDraft

        {

            get

            {

                return _isDraft;

            }

            set

            {

                if (value != _isDraft)

                {

                    _isDraft = value;

                    OnPropertyChanged("isDraft");

                }

            }

        }

        public System.String WebLink

        {

            get

            {

                return _webLink;

            }

            set

            {

                if (value != _webLink)

                {

                    _webLink = value;

                    OnPropertyChanged("webLink");

                }

            }

        }

        public global::Microsoft.Graph.InferenceClassificationType InferenceClassification

        {

            get

            {

                return _inferenceClassification;

            }

            set

            {

                if (value != _inferenceClassification)

                {

                    _inferenceClassification = value;

                    OnPropertyChanged("inferenceClassification");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IExtension> global::Microsoft.Graph.IMessage.Extensions

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IExtension, global::Microsoft.Graph.Extension>(Context, (DataServiceCollection<global::Microsoft.Graph.Extension>)Extensions);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IAttachment> global::Microsoft.Graph.IMessage.Attachments

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IAttachment, global::Microsoft.Graph.Attachment>(Context, (DataServiceCollection<global::Microsoft.Graph.Attachment>)Attachments);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ReceivedDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> receivedDateTime

        {

            get

            {

                return ReceivedDateTime;

            }

            set

            {

                ReceivedDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SentDateTime instead.")]

        public System.Nullable<System.DateTimeOffset> sentDateTime

        {

            get

            {

                return SentDateTime;

            }

            set

            {

                SentDateTime = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HasAttachments instead.")]

        public System.Nullable<System.Boolean> hasAttachments

        {

            get

            {

                return HasAttachments;

            }

            set

            {

                HasAttachments = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Subject instead.")]

        public System.String subject

        {

            get

            {

                return Subject;

            }

            set

            {

                Subject = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Body instead.")]

        public global::Microsoft.Graph.ItemBody body

        {

            get

            {

                return Body;

            }

            set

            {

                Body = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BodyPreview instead.")]

        public System.String bodyPreview

        {

            get

            {

                return BodyPreview;

            }

            set

            {

                BodyPreview = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Importance instead.")]

        public global::Microsoft.Graph.Importance importance

        {

            get

            {

                return Importance;

            }

            set

            {

                Importance = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ParentFolderId instead.")]

        public System.String parentFolderId

        {

            get

            {

                return ParentFolderId;

            }

            set

            {

                ParentFolderId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Sender instead.")]

        public global::Microsoft.Graph.Recipient sender

        {

            get

            {

                return Sender;

            }

            set

            {

                Sender = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use From instead.")]

        public global::Microsoft.Graph.Recipient from

        {

            get

            {

                return From;

            }

            set

            {

                From = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ToRecipients instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> toRecipients

        {

            get

            {

                return ToRecipients;

            }

            set

            {

                ToRecipients = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CcRecipients instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> ccRecipients

        {

            get

            {

                return CcRecipients;

            }

            set

            {

                CcRecipients = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BccRecipients instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> bccRecipients

        {

            get

            {

                return BccRecipients;

            }

            set

            {

                BccRecipients = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ReplyTo instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Recipient> replyTo

        {

            get

            {

                return ReplyTo;

            }

            set

            {

                ReplyTo = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ConversationId instead.")]

        public System.String conversationId

        {

            get

            {

                return ConversationId;

            }

            set

            {

                ConversationId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UniqueBody instead.")]

        public global::Microsoft.Graph.ItemBody uniqueBody

        {

            get

            {

                return UniqueBody;

            }

            set

            {

                UniqueBody = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsDeliveryReceiptRequested instead.")]

        public System.Nullable<System.Boolean> isDeliveryReceiptRequested

        {

            get

            {

                return IsDeliveryReceiptRequested;

            }

            set

            {

                IsDeliveryReceiptRequested = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsReadReceiptRequested instead.")]

        public System.Nullable<System.Boolean> isReadReceiptRequested

        {

            get

            {

                return IsReadReceiptRequested;

            }

            set

            {

                IsReadReceiptRequested = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsRead instead.")]

        public System.Nullable<System.Boolean> isRead

        {

            get

            {

                return IsRead;

            }

            set

            {

                IsRead = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use IsDraft instead.")]

        public System.Nullable<System.Boolean> isDraft

        {

            get

            {

                return IsDraft;

            }

            set

            {

                IsDraft = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use WebLink instead.")]

        public System.String webLink

        {

            get

            {

                return WebLink;

            }

            set

            {

                WebLink = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use InferenceClassification instead.")]

        public global::Microsoft.Graph.InferenceClassificationType inferenceClassification

        {

            get

            {

                return InferenceClassification;

            }

            set

            {

                InferenceClassification = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Extensions instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension> extensions

        {

            get

            {

                return Extensions;

            }

            set

            {

                Extensions = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Attachments instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Attachment> attachments

        {

            get

            {

                return Attachments;

            }

            set

            {

                Attachments = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension> Extensions

        {

            get

            {

                if (this._extensionsConcrete == null)

                {

                    this._extensionsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Extension>();

                    this._extensionsConcrete.SetContainer(() => GetContainingEntity("extensions"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension>)this._extensionsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Extensions.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Extensions.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Attachment> Attachments

        {

            get

            {

                if (this._attachmentsConcrete == null)

                {

                    this._attachmentsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Attachment>();

                    this._attachmentsConcrete.SetContainer(() => GetContainingEntity("attachments"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Attachment>)this._attachmentsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Attachments.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Attachments.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IExtensionCollection global::Microsoft.Graph.IMessageFetcher.Extensions

        {

            get

            {

                if (this._extensionsCollection == null)

                {

                    this._extensionsCollection = new global::Microsoft.Graph.ExtensionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Extension>(GetPath("extensions")) : null,
                       Context,
                       this,
                       GetPath("extensions"));

                }



                return this._extensionsCollection;

            }

        }

        global::Microsoft.Graph.IAttachmentCollection global::Microsoft.Graph.IMessageFetcher.Attachments

        {

            get

            {

                if (this._attachmentsCollection == null)

                {

                    this._attachmentsCollection = new global::Microsoft.Graph.AttachmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Attachment>(GetPath("attachments")) : null,
                       Context,
                       this,
                       GetPath("attachments"));

                }



                return this._attachmentsCollection;

            }

        }

        public Message()

        {

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> copyAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/copy");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> moveAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/move");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> createReplyAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/createReply");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> createReplyAllAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/createReplyAll");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> createForwardAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/createForward");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

            }

            ));

        }

        public async System.Threading.Tasks.Task replyAsync(System.String Comment)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/reply");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("Comment", (object) Comment),

            }

            );

        }

        public async System.Threading.Tasks.Task replyAllAsync(System.String Comment)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/replyAll");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("Comment", (object) Comment),

            }

            );

        }

        public async System.Threading.Tasks.Task forwardAsync(System.String Comment, System.Collections.Generic.ICollection<global::Microsoft.Graph.Recipient> ToRecipients)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/forward");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("ToRecipients", (object) ToRecipients),

            }

            );

        }

        public async System.Threading.Tasks.Task sendAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/send");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMessage> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Message, global::Microsoft.Graph.IMessage>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMessage> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> global::Microsoft.Graph.IMessageFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IMessage>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IMessageFetcher global::Microsoft.Graph.IMessageFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IMessage, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IMessageFetcher)this;

        }

    }

    internal partial class MessageFetcher : global::Microsoft.Graph.OutlookItemFetcher, global::Microsoft.Graph.IMessageFetcher

    {

        private global::Microsoft.Graph.ExtensionCollection _extensionsCollection;

        private global::Microsoft.Graph.AttachmentCollection _attachmentsCollection;

        public global::Microsoft.Graph.IExtensionCollection Extensions

        {

            get

            {

                if (this._extensionsCollection == null)

                {

                    this._extensionsCollection = new global::Microsoft.Graph.ExtensionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Extension>(GetPath("extensions")) : null,
                       Context,
                       this,
                       GetPath("extensions"));

                }



                return this._extensionsCollection;

            }

        }

        public global::Microsoft.Graph.IAttachmentCollection Attachments

        {

            get

            {

                if (this._attachmentsCollection == null)

                {

                    this._attachmentsCollection = new global::Microsoft.Graph.AttachmentCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Attachment>(GetPath("attachments")) : null,
                       Context,
                       this,
                       GetPath("attachments"));

                }



                return this._attachmentsCollection;

            }

        }

        public MessageFetcher()

        {

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> copyAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/copy");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> moveAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/move");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> createReplyAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/createReply");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> createReplyAllAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/createReplyAll");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> createForwardAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/createForward");

            return (global::Microsoft.Graph.IMessage)Enumerable.Single<global::Microsoft.Graph.Message>(await this.Context.ExecuteAsync<global::Microsoft.Graph.Message>(requestUri, "POST", true, new OperationParameter[]

            {

            }

            ));

        }

        public async System.Threading.Tasks.Task replyAsync(System.String Comment)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/reply");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("Comment", (object) Comment),

            }

            );

        }

        public async System.Threading.Tasks.Task replyAllAsync(System.String Comment)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/replyAll");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[1]

            {

                new BodyOperationParameter("Comment", (object) Comment),

            }

            );

        }

        public async System.Threading.Tasks.Task forwardAsync(System.String Comment, System.Collections.Generic.ICollection<global::Microsoft.Graph.Recipient> ToRecipients)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/forward");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[2]

            {

                new BodyOperationParameter("Comment", (object) Comment),

                new BodyOperationParameter("ToRecipients", (object) ToRecipients),

            }

            );

        }

        public async System.Threading.Tasks.Task sendAsync()

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/send");

            await this.Context.ExecuteAsync(requestUri, "POST", new OperationParameter[0]

            {

            }

            );

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IMessage> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IMessageFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IMessage, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IMessageFetcher)new global::Microsoft.Graph.MessageFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMessage> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Message, global::Microsoft.Graph.IMessage>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMessage> _query;

    }

    internal partial class MessageCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IMessage>, global::Microsoft.Graph.IMessageCollection

    {

        internal MessageCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IMessageFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IMessage>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddmessageAsync(global::Microsoft.Graph.IMessage item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IMessageFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Message>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.MessageFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class MessageCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class MailFolder : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IMailFolder, global::Microsoft.Graph.IMailFolderFetcher

    {

        private global::Microsoft.Graph.MessageCollection _messagesCollection;

        private global::Microsoft.Graph.MailFolderCollection _childFoldersCollection;

        private System.String _displayName;

        private System.String _parentFolderId;

        private System.Nullable<System.Int32> _childFolderCount;

        private System.Nullable<System.Int32> _unreadItemCount;

        private System.Nullable<System.Int32> _totalItemCount;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Message> _messagesConcrete;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.MailFolder> _childFoldersConcrete;

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String ParentFolderId

        {

            get

            {

                return _parentFolderId;

            }

            set

            {

                if (value != _parentFolderId)

                {

                    _parentFolderId = value;

                    OnPropertyChanged("parentFolderId");

                }

            }

        }

        public System.Nullable<System.Int32> ChildFolderCount

        {

            get

            {

                return _childFolderCount;

            }

            set

            {

                if (value != _childFolderCount)

                {

                    _childFolderCount = value;

                    OnPropertyChanged("childFolderCount");

                }

            }

        }

        public System.Nullable<System.Int32> UnreadItemCount

        {

            get

            {

                return _unreadItemCount;

            }

            set

            {

                if (value != _unreadItemCount)

                {

                    _unreadItemCount = value;

                    OnPropertyChanged("unreadItemCount");

                }

            }

        }

        public System.Nullable<System.Int32> TotalItemCount

        {

            get

            {

                return _totalItemCount;

            }

            set

            {

                if (value != _totalItemCount)

                {

                    _totalItemCount = value;

                    OnPropertyChanged("totalItemCount");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IMessage> global::Microsoft.Graph.IMailFolder.Messages

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IMessage, global::Microsoft.Graph.Message>(Context, (DataServiceCollection<global::Microsoft.Graph.Message>)Messages);

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IMailFolder> global::Microsoft.Graph.IMailFolder.ChildFolders

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IMailFolder, global::Microsoft.Graph.MailFolder>(Context, (DataServiceCollection<global::Microsoft.Graph.MailFolder>)ChildFolders);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ParentFolderId instead.")]

        public System.String parentFolderId

        {

            get

            {

                return ParentFolderId;

            }

            set

            {

                ParentFolderId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChildFolderCount instead.")]

        public System.Nullable<System.Int32> childFolderCount

        {

            get

            {

                return ChildFolderCount;

            }

            set

            {

                ChildFolderCount = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use UnreadItemCount instead.")]

        public System.Nullable<System.Int32> unreadItemCount

        {

            get

            {

                return UnreadItemCount;

            }

            set

            {

                UnreadItemCount = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use TotalItemCount instead.")]

        public System.Nullable<System.Int32> totalItemCount

        {

            get

            {

                return TotalItemCount;

            }

            set

            {

                TotalItemCount = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Messages instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Message> messages

        {

            get

            {

                return Messages;

            }

            set

            {

                Messages = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChildFolders instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.MailFolder> childFolders

        {

            get

            {

                return ChildFolders;

            }

            set

            {

                ChildFolders = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Message> Messages

        {

            get

            {

                if (this._messagesConcrete == null)

                {

                    this._messagesConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Message>();

                    this._messagesConcrete.SetContainer(() => GetContainingEntity("messages"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Message>)this._messagesConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Messages.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Messages.Add(i);

                    }

                }

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.MailFolder> ChildFolders

        {

            get

            {

                if (this._childFoldersConcrete == null)

                {

                    this._childFoldersConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.MailFolder>();

                    this._childFoldersConcrete.SetContainer(() => GetContainingEntity("childFolders"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.MailFolder>)this._childFoldersConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                ChildFolders.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ChildFolders.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.IMessageCollection global::Microsoft.Graph.IMailFolderFetcher.Messages

        {

            get

            {

                if (this._messagesCollection == null)

                {

                    this._messagesCollection = new global::Microsoft.Graph.MessageCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Message>(GetPath("messages")) : null,
                       Context,
                       this,
                       GetPath("messages"));

                }



                return this._messagesCollection;

            }

        }

        global::Microsoft.Graph.IMailFolderCollection global::Microsoft.Graph.IMailFolderFetcher.ChildFolders

        {

            get

            {

                if (this._childFoldersCollection == null)

                {

                    this._childFoldersCollection = new global::Microsoft.Graph.MailFolderCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.MailFolder>(GetPath("childFolders")) : null,
                       Context,
                       this,
                       GetPath("childFolders"));

                }



                return this._childFoldersCollection;

            }

        }

        public MailFolder() : base()

        {

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMailFolder> copyAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/copy");

            return (global::Microsoft.Graph.IMailFolder)Enumerable.Single<global::Microsoft.Graph.MailFolder>(await this.Context.ExecuteAsync<global::Microsoft.Graph.MailFolder>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMailFolder> moveAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/move");

            return (global::Microsoft.Graph.IMailFolder)Enumerable.Single<global::Microsoft.Graph.MailFolder>(await this.Context.ExecuteAsync<global::Microsoft.Graph.MailFolder>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMailFolder> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.MailFolder, global::Microsoft.Graph.IMailFolder>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMailFolder> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IMailFolder> global::Microsoft.Graph.IMailFolderFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IMailFolder>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IMailFolderFetcher global::Microsoft.Graph.IMailFolderFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IMailFolder, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IMailFolderFetcher)this;

        }

    }

    internal partial class MailFolderFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IMailFolderFetcher

    {

        private global::Microsoft.Graph.MessageCollection _messagesCollection;

        private global::Microsoft.Graph.MailFolderCollection _childFoldersCollection;

        public global::Microsoft.Graph.IMessageCollection Messages

        {

            get

            {

                if (this._messagesCollection == null)

                {

                    this._messagesCollection = new global::Microsoft.Graph.MessageCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Message>(GetPath("messages")) : null,
                       Context,
                       this,
                       GetPath("messages"));

                }



                return this._messagesCollection;

            }

        }

        public global::Microsoft.Graph.IMailFolderCollection ChildFolders

        {

            get

            {

                if (this._childFoldersCollection == null)

                {

                    this._childFoldersCollection = new global::Microsoft.Graph.MailFolderCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.MailFolder>(GetPath("childFolders")) : null,
                       Context,
                       this,
                       GetPath("childFolders"));

                }



                return this._childFoldersCollection;

            }

        }

        public MailFolderFetcher() : base()

        {

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMailFolder> copyAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/copy");

            return (global::Microsoft.Graph.IMailFolder)Enumerable.Single<global::Microsoft.Graph.MailFolder>(await this.Context.ExecuteAsync<global::Microsoft.Graph.MailFolder>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async System.Threading.Tasks.Task<global::Microsoft.Graph.IMailFolder> moveAsync(System.String DestinationId)

        {

            if (this.Context == null)

                throw new InvalidOperationException("Not Initialized");

            Uri myUri = this.GetUrl();

            if (myUri == (Uri)null)

                throw new Exception("cannot find entity");

            Uri requestUri = new Uri(myUri.ToString().TrimEnd('/') + "/move");

            return (global::Microsoft.Graph.IMailFolder)Enumerable.Single<global::Microsoft.Graph.MailFolder>(await this.Context.ExecuteAsync<global::Microsoft.Graph.MailFolder>(requestUri, "POST", true, new OperationParameter[]

            {

                new BodyOperationParameter("DestinationId", (object) DestinationId),

            }

            ));

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IMailFolder> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IMailFolderFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IMailFolder, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IMailFolderFetcher)new global::Microsoft.Graph.MailFolderFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMailFolder> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.MailFolder, global::Microsoft.Graph.IMailFolder>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IMailFolder> _query;

    }

    internal partial class MailFolderCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IMailFolder>, global::Microsoft.Graph.IMailFolderCollection

    {

        internal MailFolderCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IMailFolderFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IMailFolder>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddmailFolderAsync(global::Microsoft.Graph.IMailFolder item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IMailFolderFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.MailFolder>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.MailFolderFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class MailFolderCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class CalendarGroup : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.ICalendarGroup, global::Microsoft.Graph.ICalendarGroupFetcher

    {

        private global::Microsoft.Graph.CalendarCollection _calendarsCollection;

        private System.String _name;

        private System.Nullable<System.Guid> _classId;

        private System.String _changeKey;

        private System.String _id;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Calendar> _calendarsConcrete;

        public System.String Name

        {

            get

            {

                return _name;

            }

            set

            {

                if (value != _name)

                {

                    _name = value;

                    OnPropertyChanged("name");

                }

            }

        }

        public System.Nullable<System.Guid> ClassId

        {

            get

            {

                return _classId;

            }

            set

            {

                if (value != _classId)

                {

                    _classId = value;

                    OnPropertyChanged("classId");

                }

            }

        }

        public System.String ChangeKey

        {

            get

            {

                return _changeKey;

            }

            set

            {

                if (value != _changeKey)

                {

                    _changeKey = value;

                    OnPropertyChanged("changeKey");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ICalendar> global::Microsoft.Graph.ICalendarGroup.Calendars

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.ICalendar, global::Microsoft.Graph.Calendar>(Context, (DataServiceCollection<global::Microsoft.Graph.Calendar>)Calendars);

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Name instead.")]

        public System.String name

        {

            get

            {

                return Name;

            }

            set

            {

                Name = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ClassId instead.")]

        public System.Nullable<System.Guid> classId

        {

            get

            {

                return ClassId;

            }

            set

            {

                ClassId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ChangeKey instead.")]

        public System.String changeKey

        {

            get

            {

                return ChangeKey;

            }

            set

            {

                ChangeKey = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Calendars instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Calendar> calendars

        {

            get

            {

                return Calendars;

            }

            set

            {

                Calendars = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Calendar> Calendars

        {

            get

            {

                if (this._calendarsConcrete == null)

                {

                    this._calendarsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Calendar>();

                    this._calendarsConcrete.SetContainer(() => GetContainingEntity("calendars"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Calendar>)this._calendarsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Calendars.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Calendars.Add(i);

                    }

                }

            }

        }

        global::Microsoft.Graph.ICalendarCollection global::Microsoft.Graph.ICalendarGroupFetcher.Calendars

        {

            get

            {

                if (this._calendarsCollection == null)

                {

                    this._calendarsCollection = new global::Microsoft.Graph.CalendarCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Calendar>(GetPath("calendars")) : null,
                       Context,
                       this,
                       GetPath("calendars"));

                }



                return this._calendarsCollection;

            }

        }

        public CalendarGroup() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendarGroup> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.CalendarGroup, global::Microsoft.Graph.ICalendarGroup>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendarGroup> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.ICalendarGroup> global::Microsoft.Graph.ICalendarGroupFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.ICalendarGroup>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.ICalendarGroupFetcher global::Microsoft.Graph.ICalendarGroupFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.ICalendarGroup, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.ICalendarGroupFetcher)this;

        }

    }

    internal partial class CalendarGroupFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.ICalendarGroupFetcher

    {

        private global::Microsoft.Graph.CalendarCollection _calendarsCollection;

        public global::Microsoft.Graph.ICalendarCollection Calendars

        {

            get

            {

                if (this._calendarsCollection == null)

                {

                    this._calendarsCollection = new global::Microsoft.Graph.CalendarCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Calendar>(GetPath("calendars")) : null,
                       Context,
                       this,
                       GetPath("calendars"));

                }



                return this._calendarsCollection;

            }

        }

        public CalendarGroupFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.ICalendarGroup> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.ICalendarGroupFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.ICalendarGroup, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.ICalendarGroupFetcher)new global::Microsoft.Graph.CalendarGroupFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendarGroup> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.CalendarGroup, global::Microsoft.Graph.ICalendarGroup>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.ICalendarGroup> _query;

    }

    internal partial class CalendarGroupCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.ICalendarGroup>, global::Microsoft.Graph.ICalendarGroupCollection

    {

        internal CalendarGroupCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.ICalendarGroupFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.ICalendarGroup>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddcalendarGroupAsync(global::Microsoft.Graph.ICalendarGroup item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.ICalendarGroupFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.CalendarGroup>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.CalendarGroupFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class CalendarGroupCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Person : Microsoft.OData.ProxyExtensions.EntityBase, global::Microsoft.Graph.IPerson, global::Microsoft.Graph.IPersonFetcher

    {

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.PersonDataSource> _sources;

        private System.String _displayName;

        private System.String _givenName;

        private System.String _surname;

        private System.String _title;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Email> _emailAddresses;

        private System.String _companyName;

        private System.String _officeLocation;

        private System.String _id;

        public System.Collections.Generic.IList<global::Microsoft.Graph.PersonDataSource> Sources

        {

            get

            {

                if (this._sources == default(System.Collections.Generic.IList<global::Microsoft.Graph.PersonDataSource>))

                {

                    this._sources = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.PersonDataSource>();

                    this._sources.SetContainer(() => GetContainingEntity("sources"));

                }

                return this._sources;

            }

            set

            {

                Sources.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Sources.Add(i);

                    }

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String GivenName

        {

            get

            {

                return _givenName;

            }

            set

            {

                if (value != _givenName)

                {

                    _givenName = value;

                    OnPropertyChanged("givenName");

                }

            }

        }

        public System.String Surname

        {

            get

            {

                return _surname;

            }

            set

            {

                if (value != _surname)

                {

                    _surname = value;

                    OnPropertyChanged("surname");

                }

            }

        }

        public System.String Title

        {

            get

            {

                return _title;

            }

            set

            {

                if (value != _title)

                {

                    _title = value;

                    OnPropertyChanged("title");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.Email> EmailAddresses

        {

            get

            {

                if (this._emailAddresses == default(System.Collections.Generic.IList<global::Microsoft.Graph.Email>))

                {

                    this._emailAddresses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.Email>();

                    this._emailAddresses.SetContainer(() => GetContainingEntity("emailAddresses"));

                }

                return this._emailAddresses;

            }

            set

            {

                EmailAddresses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        EmailAddresses.Add(i);

                    }

                }

            }

        }

        public System.String CompanyName

        {

            get

            {

                return _companyName;

            }

            set

            {

                if (value != _companyName)

                {

                    _companyName = value;

                    OnPropertyChanged("companyName");

                }

            }

        }

        public System.String OfficeLocation

        {

            get

            {

                return _officeLocation;

            }

            set

            {

                if (value != _officeLocation)

                {

                    _officeLocation = value;

                    OnPropertyChanged("officeLocation");

                }

            }

        }

        public System.String Id

        {

            get

            {

                return _id;

            }

            set

            {

                if (value != _id)

                {

                    _id = value;

                    OnPropertyChanged("id");

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Sources instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.PersonDataSource> sources

        {

            get

            {

                return Sources;

            }

            set

            {

                Sources = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use GivenName instead.")]

        public System.String givenName

        {

            get

            {

                return GivenName;

            }

            set

            {

                GivenName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Surname instead.")]

        public System.String surname

        {

            get

            {

                return Surname;

            }

            set

            {

                Surname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Title instead.")]

        public System.String title

        {

            get

            {

                return Title;

            }

            set

            {

                Title = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EmailAddresses instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Email> emailAddresses

        {

            get

            {

                return EmailAddresses;

            }

            set

            {

                EmailAddresses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CompanyName instead.")]

        public System.String companyName

        {

            get

            {

                return CompanyName;

            }

            set

            {

                CompanyName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OfficeLocation instead.")]

        public System.String officeLocation

        {

            get

            {

                return OfficeLocation;

            }

            set

            {

                OfficeLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Id instead.")]

        public System.String id

        {

            get

            {

                return Id;

            }

            set

            {

                Id = value;

            }

        }

        public Person() : base()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPerson> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Person, global::Microsoft.Graph.IPerson>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPerson> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IPerson> global::Microsoft.Graph.IPersonFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IPerson>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IPersonFetcher global::Microsoft.Graph.IPersonFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IPerson, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IPersonFetcher)this;

        }

    }

    internal partial class PersonFetcher : Microsoft.OData.ProxyExtensions.RestShallowObjectFetcher, global::Microsoft.Graph.IPersonFetcher

    {

        public PersonFetcher() : base()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IPerson> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IPersonFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IPerson, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IPersonFetcher)new global::Microsoft.Graph.PersonFetcher()

            {

                _query = this.EnsureQuery().Expand<TTarget>(navigationPropertyAccessor)

            }

            ;

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPerson> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Person, global::Microsoft.Graph.IPerson>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IPerson> _query;

    }

    internal partial class PersonCollection : Microsoft.OData.ProxyExtensions.QueryableSet<global::Microsoft.Graph.IPerson>, global::Microsoft.Graph.IPersonCollection

    {

        internal PersonCollection(global::Microsoft.OData.Client.DataServiceQuery inner, Microsoft.OData.ProxyExtensions.DataServiceContextWrapper context, object entity, string path) : base(inner, context, entity as Microsoft.OData.ProxyExtensions.EntityBase, path)

        {

        }

        public global::Microsoft.Graph.IPersonFetcher GetById(System.String id)

        {

            return this[id];

        }

        public global::System.Threading.Tasks.Task<Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IPerson>> ExecuteAsync()

        {

            return ExecuteAsyncInternal();

        }

        public global::System.Threading.Tasks.Task AddpersonAsync(global::Microsoft.Graph.IPerson item, System.Boolean deferSaveChanges = false)

        {

            if (Entity == null)

            {

                Context.AddObject(Path, item);

            }

            else

            {

                var lastSlash = Path.LastIndexOf('/');

                var shortPath = (lastSlash >= 0 && lastSlash < Path.Length - 1) ? Path.Substring(lastSlash + 1) : Path;

                Context.AddRelatedObject(Entity, shortPath, item);

            }

            if (!deferSaveChanges)

            {

                return Context.SaveChangesAsync();

            }

            else

            {

                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();

                retVal.SetResult(null);

                return retVal.Task;

            }

        }

        public global::Microsoft.Graph.IPersonFetcher this[System.String id]

        {

            get

            {

                var path = GetPath<global::Microsoft.Graph.Person>((i) => i.Id == id);

                var fetcher = new global::Microsoft.Graph.PersonFetcher();

                fetcher.Initialize(Context, path);



                return fetcher;

            }

        }

    }

    internal partial class PersonCollection

    {

        public global::System.Threading.Tasks.Task<System.Int64> CountAsync()

        {

            return new DataServiceQuerySingle<long>(Context, Path + "/$count").GetValueAsync();

        }

    }

    [global::Microsoft.OData.Client.Key("id")]

    public partial class Contact : global::Microsoft.Graph.OutlookItem, global::Microsoft.Graph.IContact, global::Microsoft.Graph.IContactFetcher

    {

        private global::Microsoft.Graph.ProfilePhoto _photo;

        private global::Microsoft.Graph.ProfilePhotoFetcher _photoFetcher;

        private global::Microsoft.Graph.ExtensionCollection _extensionsCollection;

        private System.String _parentFolderId;

        private System.Nullable<System.DateTimeOffset> _birthday;

        private System.String _fileAs;

        private System.String _displayName;

        private System.String _givenName;

        private System.String _initials;

        private System.String _middleName;

        private System.String _nickName;

        private System.String _surname;

        private System.String _title;

        private System.String _yomiGivenName;

        private System.String _yomiSurname;

        private System.String _yomiCompanyName;

        private System.String _generation;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.EmailAddress> _emailAddresses;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _imAddresses;

        private System.String _jobTitle;

        private System.String _companyName;

        private System.String _department;

        private System.String _officeLocation;

        private System.String _profession;

        private System.String _businessHomePage;

        private System.String _assistantName;

        private System.String _manager;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _homePhones;

        private System.String _mobilePhone1;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _businessPhones;

        private global::Microsoft.Graph.PhysicalAddress _homeAddress;

        private global::Microsoft.Graph.PhysicalAddress _businessAddress;

        private global::Microsoft.Graph.PhysicalAddress _otherAddress;

        private System.String _spouseName;

        private System.String _personalNotes;

        private Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String> _children;

        private Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Extension> _extensionsConcrete;

        public System.String ParentFolderId

        {

            get

            {

                return _parentFolderId;

            }

            set

            {

                if (value != _parentFolderId)

                {

                    _parentFolderId = value;

                    OnPropertyChanged("parentFolderId");

                }

            }

        }

        public System.Nullable<System.DateTimeOffset> Birthday

        {

            get

            {

                return _birthday;

            }

            set

            {

                if (value != _birthday)

                {

                    _birthday = value;

                    OnPropertyChanged("birthday");

                }

            }

        }

        public System.String FileAs

        {

            get

            {

                return _fileAs;

            }

            set

            {

                if (value != _fileAs)

                {

                    _fileAs = value;

                    OnPropertyChanged("fileAs");

                }

            }

        }

        public System.String DisplayName

        {

            get

            {

                return _displayName;

            }

            set

            {

                if (value != _displayName)

                {

                    _displayName = value;

                    OnPropertyChanged("displayName");

                }

            }

        }

        public System.String GivenName

        {

            get

            {

                return _givenName;

            }

            set

            {

                if (value != _givenName)

                {

                    _givenName = value;

                    OnPropertyChanged("givenName");

                }

            }

        }

        public System.String Initials

        {

            get

            {

                return _initials;

            }

            set

            {

                if (value != _initials)

                {

                    _initials = value;

                    OnPropertyChanged("initials");

                }

            }

        }

        public System.String MiddleName

        {

            get

            {

                return _middleName;

            }

            set

            {

                if (value != _middleName)

                {

                    _middleName = value;

                    OnPropertyChanged("middleName");

                }

            }

        }

        public System.String NickName

        {

            get

            {

                return _nickName;

            }

            set

            {

                if (value != _nickName)

                {

                    _nickName = value;

                    OnPropertyChanged("nickName");

                }

            }

        }

        public System.String Surname

        {

            get

            {

                return _surname;

            }

            set

            {

                if (value != _surname)

                {

                    _surname = value;

                    OnPropertyChanged("surname");

                }

            }

        }

        public System.String Title

        {

            get

            {

                return _title;

            }

            set

            {

                if (value != _title)

                {

                    _title = value;

                    OnPropertyChanged("title");

                }

            }

        }

        public System.String YomiGivenName

        {

            get

            {

                return _yomiGivenName;

            }

            set

            {

                if (value != _yomiGivenName)

                {

                    _yomiGivenName = value;

                    OnPropertyChanged("yomiGivenName");

                }

            }

        }

        public System.String YomiSurname

        {

            get

            {

                return _yomiSurname;

            }

            set

            {

                if (value != _yomiSurname)

                {

                    _yomiSurname = value;

                    OnPropertyChanged("yomiSurname");

                }

            }

        }

        public System.String YomiCompanyName

        {

            get

            {

                return _yomiCompanyName;

            }

            set

            {

                if (value != _yomiCompanyName)

                {

                    _yomiCompanyName = value;

                    OnPropertyChanged("yomiCompanyName");

                }

            }

        }

        public System.String Generation

        {

            get

            {

                return _generation;

            }

            set

            {

                if (value != _generation)

                {

                    _generation = value;

                    OnPropertyChanged("generation");

                }

            }

        }

        public System.Collections.Generic.IList<global::Microsoft.Graph.EmailAddress> EmailAddresses

        {

            get

            {

                if (this._emailAddresses == default(System.Collections.Generic.IList<global::Microsoft.Graph.EmailAddress>))

                {

                    this._emailAddresses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<global::Microsoft.Graph.EmailAddress>();

                    this._emailAddresses.SetContainer(() => GetContainingEntity("emailAddresses"));

                }

                return this._emailAddresses;

            }

            set

            {

                EmailAddresses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        EmailAddresses.Add(i);

                    }

                }

            }

        }

        public System.Collections.Generic.IList<System.String> ImAddresses

        {

            get

            {

                if (this._imAddresses == default(System.Collections.Generic.IList<System.String>))

                {

                    this._imAddresses = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._imAddresses.SetContainer(() => GetContainingEntity("imAddresses"));

                }

                return this._imAddresses;

            }

            set

            {

                ImAddresses.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        ImAddresses.Add(i);

                    }

                }

            }

        }

        public System.String JobTitle

        {

            get

            {

                return _jobTitle;

            }

            set

            {

                if (value != _jobTitle)

                {

                    _jobTitle = value;

                    OnPropertyChanged("jobTitle");

                }

            }

        }

        public System.String CompanyName

        {

            get

            {

                return _companyName;

            }

            set

            {

                if (value != _companyName)

                {

                    _companyName = value;

                    OnPropertyChanged("companyName");

                }

            }

        }

        public System.String Department

        {

            get

            {

                return _department;

            }

            set

            {

                if (value != _department)

                {

                    _department = value;

                    OnPropertyChanged("department");

                }

            }

        }

        public System.String OfficeLocation

        {

            get

            {

                return _officeLocation;

            }

            set

            {

                if (value != _officeLocation)

                {

                    _officeLocation = value;

                    OnPropertyChanged("officeLocation");

                }

            }

        }

        public System.String Profession

        {

            get

            {

                return _profession;

            }

            set

            {

                if (value != _profession)

                {

                    _profession = value;

                    OnPropertyChanged("profession");

                }

            }

        }

        public System.String BusinessHomePage

        {

            get

            {

                return _businessHomePage;

            }

            set

            {

                if (value != _businessHomePage)

                {

                    _businessHomePage = value;

                    OnPropertyChanged("businessHomePage");

                }

            }

        }

        public System.String AssistantName

        {

            get

            {

                return _assistantName;

            }

            set

            {

                if (value != _assistantName)

                {

                    _assistantName = value;

                    OnPropertyChanged("assistantName");

                }

            }

        }

        public System.String Manager

        {

            get

            {

                return _manager;

            }

            set

            {

                if (value != _manager)

                {

                    _manager = value;

                    OnPropertyChanged("manager");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> HomePhones

        {

            get

            {

                if (this._homePhones == default(System.Collections.Generic.IList<System.String>))

                {

                    this._homePhones = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._homePhones.SetContainer(() => GetContainingEntity("homePhones"));

                }

                return this._homePhones;

            }

            set

            {

                HomePhones.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        HomePhones.Add(i);

                    }

                }

            }

        }

        public System.String MobilePhone1

        {

            get

            {

                return _mobilePhone1;

            }

            set

            {

                if (value != _mobilePhone1)

                {

                    _mobilePhone1 = value;

                    OnPropertyChanged("mobilePhone1");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> BusinessPhones

        {

            get

            {

                if (this._businessPhones == default(System.Collections.Generic.IList<System.String>))

                {

                    this._businessPhones = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._businessPhones.SetContainer(() => GetContainingEntity("businessPhones"));

                }

                return this._businessPhones;

            }

            set

            {

                BusinessPhones.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        BusinessPhones.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.PhysicalAddress HomeAddress

        {

            get

            {

                return _homeAddress;

            }

            set

            {

                if (value != _homeAddress)

                {

                    _homeAddress = value;

                    OnPropertyChanged("homeAddress");

                }

            }

        }

        public global::Microsoft.Graph.PhysicalAddress BusinessAddress

        {

            get

            {

                return _businessAddress;

            }

            set

            {

                if (value != _businessAddress)

                {

                    _businessAddress = value;

                    OnPropertyChanged("businessAddress");

                }

            }

        }

        public global::Microsoft.Graph.PhysicalAddress OtherAddress

        {

            get

            {

                return _otherAddress;

            }

            set

            {

                if (value != _otherAddress)

                {

                    _otherAddress = value;

                    OnPropertyChanged("otherAddress");

                }

            }

        }

        public System.String SpouseName

        {

            get

            {

                return _spouseName;

            }

            set

            {

                if (value != _spouseName)

                {

                    _spouseName = value;

                    OnPropertyChanged("spouseName");

                }

            }

        }

        public System.String PersonalNotes

        {

            get

            {

                return _personalNotes;

            }

            set

            {

                if (value != _personalNotes)

                {

                    _personalNotes = value;

                    OnPropertyChanged("personalNotes");

                }

            }

        }

        public System.Collections.Generic.IList<System.String> Children

        {

            get

            {

                if (this._children == default(System.Collections.Generic.IList<System.String>))

                {

                    this._children = new Microsoft.OData.ProxyExtensions.NonEntityTypeCollectionImpl<System.String>();

                    this._children.SetContainer(() => GetContainingEntity("children"));

                }

                return this._children;

            }

            set

            {

                Children.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Children.Add(i);

                    }

                }

            }

        }

        Microsoft.OData.ProxyExtensions.IPagedCollection<global::Microsoft.Graph.IExtension> global::Microsoft.Graph.IContact.Extensions

        {

            get

            {

                return new Microsoft.OData.ProxyExtensions.PagedCollection<global::Microsoft.Graph.IExtension, global::Microsoft.Graph.Extension>(Context, (DataServiceCollection<global::Microsoft.Graph.Extension>)Extensions);

            }

        }

        global::Microsoft.Graph.IProfilePhoto global::Microsoft.Graph.IContact.Photo

        {

            get

            {

                return this._photo;

            }

            set

            {

                if (this.Photo != value)

                {

                    this.Photo = (global::Microsoft.Graph.ProfilePhoto)value;

                }

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ParentFolderId instead.")]

        public System.String parentFolderId

        {

            get

            {

                return ParentFolderId;

            }

            set

            {

                ParentFolderId = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Birthday instead.")]

        public System.Nullable<System.DateTimeOffset> birthday

        {

            get

            {

                return Birthday;

            }

            set

            {

                Birthday = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use FileAs instead.")]

        public System.String fileAs

        {

            get

            {

                return FileAs;

            }

            set

            {

                FileAs = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use DisplayName instead.")]

        public System.String displayName

        {

            get

            {

                return DisplayName;

            }

            set

            {

                DisplayName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use GivenName instead.")]

        public System.String givenName

        {

            get

            {

                return GivenName;

            }

            set

            {

                GivenName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Initials instead.")]

        public System.String initials

        {

            get

            {

                return Initials;

            }

            set

            {

                Initials = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MiddleName instead.")]

        public System.String middleName

        {

            get

            {

                return MiddleName;

            }

            set

            {

                MiddleName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use NickName instead.")]

        public System.String nickName

        {

            get

            {

                return NickName;

            }

            set

            {

                NickName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Surname instead.")]

        public System.String surname

        {

            get

            {

                return Surname;

            }

            set

            {

                Surname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Title instead.")]

        public System.String title

        {

            get

            {

                return Title;

            }

            set

            {

                Title = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use YomiGivenName instead.")]

        public System.String yomiGivenName

        {

            get

            {

                return YomiGivenName;

            }

            set

            {

                YomiGivenName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use YomiSurname instead.")]

        public System.String yomiSurname

        {

            get

            {

                return YomiSurname;

            }

            set

            {

                YomiSurname = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use YomiCompanyName instead.")]

        public System.String yomiCompanyName

        {

            get

            {

                return YomiCompanyName;

            }

            set

            {

                YomiCompanyName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Generation instead.")]

        public System.String generation

        {

            get

            {

                return Generation;

            }

            set

            {

                Generation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use EmailAddresses instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.EmailAddress> emailAddresses

        {

            get

            {

                return EmailAddresses;

            }

            set

            {

                EmailAddresses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use ImAddresses instead.")]

        public global::System.Collections.Generic.IList<System.String> imAddresses

        {

            get

            {

                return ImAddresses;

            }

            set

            {

                ImAddresses = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use JobTitle instead.")]

        public System.String jobTitle

        {

            get

            {

                return JobTitle;

            }

            set

            {

                JobTitle = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use CompanyName instead.")]

        public System.String companyName

        {

            get

            {

                return CompanyName;

            }

            set

            {

                CompanyName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Department instead.")]

        public System.String department

        {

            get

            {

                return Department;

            }

            set

            {

                Department = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OfficeLocation instead.")]

        public System.String officeLocation

        {

            get

            {

                return OfficeLocation;

            }

            set

            {

                OfficeLocation = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Profession instead.")]

        public System.String profession

        {

            get

            {

                return Profession;

            }

            set

            {

                Profession = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BusinessHomePage instead.")]

        public System.String businessHomePage

        {

            get

            {

                return BusinessHomePage;

            }

            set

            {

                BusinessHomePage = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use AssistantName instead.")]

        public System.String assistantName

        {

            get

            {

                return AssistantName;

            }

            set

            {

                AssistantName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Manager instead.")]

        public System.String manager

        {

            get

            {

                return Manager;

            }

            set

            {

                Manager = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HomePhones instead.")]

        public global::System.Collections.Generic.IList<System.String> homePhones

        {

            get

            {

                return HomePhones;

            }

            set

            {

                HomePhones = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use MobilePhone1 instead.")]

        public System.String mobilePhone1

        {

            get

            {

                return MobilePhone1;

            }

            set

            {

                MobilePhone1 = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BusinessPhones instead.")]

        public global::System.Collections.Generic.IList<System.String> businessPhones

        {

            get

            {

                return BusinessPhones;

            }

            set

            {

                BusinessPhones = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use HomeAddress instead.")]

        public global::Microsoft.Graph.PhysicalAddress homeAddress

        {

            get

            {

                return HomeAddress;

            }

            set

            {

                HomeAddress = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use BusinessAddress instead.")]

        public global::Microsoft.Graph.PhysicalAddress businessAddress

        {

            get

            {

                return BusinessAddress;

            }

            set

            {

                BusinessAddress = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use OtherAddress instead.")]

        public global::Microsoft.Graph.PhysicalAddress otherAddress

        {

            get

            {

                return OtherAddress;

            }

            set

            {

                OtherAddress = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use SpouseName instead.")]

        public System.String spouseName

        {

            get

            {

                return SpouseName;

            }

            set

            {

                SpouseName = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use PersonalNotes instead.")]

        public System.String personalNotes

        {

            get

            {

                return PersonalNotes;

            }

            set

            {

                PersonalNotes = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Children instead.")]

        public global::System.Collections.Generic.IList<System.String> children

        {

            get

            {

                return Children;

            }

            set

            {

                Children = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Extensions instead.")]

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension> extensions

        {

            get

            {

                return Extensions;

            }

            set

            {

                Extensions = value;

            }

        }

        [EditorBrowsable(EditorBrowsableState.Never)]

        [Obsolete("Use Photo instead.")]

        public global::Microsoft.Graph.ProfilePhoto photo

        {

            get

            {

                return Photo;

            }

            set

            {

                Photo = value;

            }

        }

        public global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension> Extensions

        {

            get

            {

                if (this._extensionsConcrete == null)

                {

                    this._extensionsConcrete = new Microsoft.OData.ProxyExtensions.EntityCollectionImpl<global::Microsoft.Graph.Extension>();

                    this._extensionsConcrete.SetContainer(() => GetContainingEntity("extensions"));

                }



                return (global::System.Collections.Generic.IList<global::Microsoft.Graph.Extension>)this._extensionsConcrete;

            }

            set

            {

                if (this.Context == null)

                    throw new InvalidOperationException("Not Initialized");

                Extensions.Clear();

                if (value != null)

                {

                    foreach (var i in value)

                    {

                        Extensions.Add(i);

                    }

                }

            }

        }

        public global::Microsoft.Graph.ProfilePhoto Photo

        {

            get

            {

                return this._photo;

            }

            set

            {

                if (this._photo != value)

                {

                    this._photo = value;

                    if (Context != null && Context.GetEntityDescriptor(this) != null && (value == null || Context.GetEntityDescriptor(value) != null))

                    {

                        Context.SetLink(this, "photo", value);

                    }

                }

            }

        }

        global::Microsoft.Graph.IExtensionCollection global::Microsoft.Graph.IContactFetcher.Extensions

        {

            get

            {

                if (this._extensionsCollection == null)

                {

                    this._extensionsCollection = new global::Microsoft.Graph.ExtensionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Extension>(GetPath("extensions")) : null,
                       Context,
                       this,
                       GetPath("extensions"));

                }



                return this._extensionsCollection;

            }

        }

        global::Microsoft.Graph.IProfilePhotoFetcher global::Microsoft.Graph.IContactFetcher.Photo

        {

            get

            {

                if (this._photoFetcher == null)

                {

                    this._photoFetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                    this._photoFetcher.Initialize(this.Context, GetPath("photo"));

                }



                return this._photoFetcher;

            }

        }

        public Contact()

        {

        }

        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IContact> EnsureQuery()

        {

            if (this._query == null)

            {

                this._query = CreateQuery<global::Microsoft.Graph.Contact, global::Microsoft.Graph.IContact>();

            }

            return this._query;

        }



        private Microsoft.OData.ProxyExtensions.IReadOnlyQueryableSet<global::Microsoft.Graph.IContact> _query;

        global::System.Threading.Tasks.Task<global::Microsoft.Graph.IContact> global::Microsoft.Graph.IContactFetcher.ExecuteAsync()

        {

            var tsc = new global::System.Threading.Tasks.TaskCompletionSource<global::Microsoft.Graph.IContact>();

            tsc.SetResult(this);

            return tsc.Task;

        }

        global::Microsoft.Graph.IContactFetcher global::Microsoft.Graph.IContactFetcher.Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IContact, TTarget>> navigationPropertyAccessor)

        {

            return (global::Microsoft.Graph.IContactFetcher)this;

        }

    }

    internal partial class ContactFetcher : global::Microsoft.Graph.OutlookItemFetcher, global::Microsoft.Graph.IContactFetcher

    {

        private global::Microsoft.Graph.ProfilePhotoFetcher _photoFetcher;

        private global::Microsoft.Graph.ExtensionCollection _extensionsCollection;

        public global::Microsoft.Graph.IExtensionCollection Extensions

        {

            get

            {

                if (this._extensionsCollection == null)

                {

                    this._extensionsCollection = new global::Microsoft.Graph.ExtensionCollection(
                       Context != null ? Context.CreateQuery<global::Microsoft.Graph.Extension>(GetPath("extensions")) : null,
                       Context,
                       this,
                       GetPath("extensions"));

                }



                return this._extensionsCollection;

            }

        }

        public global::Microsoft.Graph.IProfilePhotoFetcher Photo

        {

            get

            {

                if (this._photoFetcher == null)

                {

                    this._photoFetcher = new global::Microsoft.Graph.ProfilePhotoFetcher();

                    this._photoFetcher.Initialize(this.Context, GetPath("photo"));

                }



                return this._photoFetcher;

            }

        }

        public ContactFetcher()

        {

        }

        public async global::System.Threading.Tasks.Task<global::Microsoft.Graph.IContact> ExecuteAsync()

        {

            return await EnsureQuery().ExecuteSingleAsync();

        }

        public global::Microsoft.Graph.IContactFetcher Expand<TTarget>(System.Linq.Expressions.Expression<System.Func<global::Microsoft.Graph.IContact, TTarget>> navigationPropertyAccessor)

        {


            {


            }

            ;

