using System.Collections.Generic;
using Newtonsoft.Json;

namespace HiRezApi.AutoRestGen.App
{
    public class SwaggerDocument
    {
        public readonly string swagger = "2.0";

        public string basePath;

        public IList<string> consumes;

        public IDictionary<string, Schema> definitions;

        public ExternalDocs externalDocs;

        public string host;

        public Info info;

        public IDictionary<string, Parameter> parameters;

        public IDictionary<string, PathItem> paths;

        public IList<string> produces;

        public IDictionary<string, Response> responses;

        public IList<string> schemes;

        public IList<IDictionary<string, IEnumerable<string>>> security;

        public IDictionary<string, SecurityScheme> securityDefinitions;

        public IList<Tag> tags;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }

    public class Info
    {
        public Contact contact;

        public string description;

        public License license;

        public string termsOfService;

        public string title;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
        public string version;
    }

    public class Contact
    {
        public string email;
        public string name;

        public string url;
    }

    public class License
    {
        public string name;

        public string url;
    }

    public class PathItem
    {
        public Operation delete;

        public Operation get;

        public Operation head;

        public Operation options;

        public IList<Parameter> parameters;

        public Operation patch;

        public Operation post;

        public Operation put;
        [JsonProperty("$ref")] public string @ref;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }

    public class Operation
    {
        public IList<string> consumes;

        public bool? deprecated;

        public string description;

        public ExternalDocs externalDocs;

        public string operationId;

        public IList<Parameter> parameters;

        public IList<string> produces;

        public IDictionary<string, Response> responses;

        public IList<string> schemes;

        public IList<IDictionary<string, IEnumerable<string>>> security;

        public string summary;
        public IList<string> tags;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }

    public class Tag
    {
        public string description;

        public ExternalDocs externalDocs;
        public string name;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }

    public class ExternalDocs
    {
        public string description;

        public string url;
    }

    public class Parameter : PartialSchema
    {
        public string description;

        public string @in;

        public string name;
        [JsonProperty("$ref")] public string @ref;

        public bool? required;

        public Schema schema;
    }

    public class Schema
    {
        public Schema additionalProperties;

        public IList<Schema> allOf;

        public object @default;

        public string description;

        public string discriminator;

        public IList<object> @enum;

        public object example;

        public bool? exclusiveMaximum;

        public bool? exclusiveMinimum;

        public ExternalDocs externalDocs;

        public string format;

        public Schema items;

        public int? maximum;

        public int? maxItems;

        public int? maxLength;

        public int? maxProperties;

        public int? minimum;

        public int? minItems;

        public int? minLength;

        public int? minProperties;

        public int? multipleOf;

        public string pattern;

        public IDictionary<string, Schema> properties;

        public bool? readOnly;
        [JsonProperty("$ref")] public string @ref;

        public IList<string> required;

        public string title;

        public string type;

        public bool? uniqueItems;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();

        public Xml xml;

        [JsonProperty(PropertyName = "x-ms-client-name")]
        public string xname;
    }

    public class PartialSchema
    {
        public string collectionFormat;

        public object @default;

        public IList<object> @enum;

        public bool? exclusiveMaximum;

        public bool? exclusiveMinimum;

        public string format;

        public PartialSchema items;

        public int? maximum;

        public int? maxItems;

        public int? maxLength;

        public int? minimum;

        public int? minItems;

        public int? minLength;

        public int? multipleOf;

        public string pattern;
        public string type;

        public bool? uniqueItems;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }

    public class Response
    {
        public string description;

        public object examples;

        public IDictionary<string, Header> headers;

        public Schema schema;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }

    public class Header : PartialSchema
    {
        public string description;
    }

    public class Xml
    {
        public bool? attribute;
        public string name;

        public string @namespace;

        public string prefix;

        public bool? wrapped;
    }

    public class SecurityScheme
    {
        public string authorizationUrl;

        public string description;

        public string flow;

        public string @in;

        public string name;

        public IDictionary<string, string> scopes;

        public string tokenUrl;
        public string type;

        public Dictionary<string, object> vendorExtensions = new Dictionary<string, object>();
    }
}