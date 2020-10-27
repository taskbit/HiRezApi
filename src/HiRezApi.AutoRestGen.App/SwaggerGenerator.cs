using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using HiRezApi.Common;
using HiRezApi.Paladins;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HiRezApi.AutoRestGen.App
{
    internal class SwaggerGenerator
    {
        private readonly string _jsonModelDirectory;

        public SwaggerGenerator(string jsonModelDirectory)
        {
            _jsonModelDirectory = jsonModelDirectory;
        }

        public void Generate()
        {
            var document = CreateDocBase();

            AddPath("createsession", "Session", "CreateSession", document);
            ParseResponse("Session", document);

            AddPath("getdataused", "DataUsed", "GetDataUsed", document);
            ParseResponse("DataUsed", document);

            AddPath("getdemodetails", "DemoDetails", "GetDemoDetails", document, ("matchId", typeof(int)));
            ParseResponse("DemoDetails", document);

            AddPath("getesportsproleaguedetails", "ESportsProLeagueDetails", "GetESportsProLeagueDetails", document);
            ParseResponse("ESportsProLeagueDetails", document);

            AddPath("getfriends", "Friends", "GetFriends", document, ("player", typeof(string)));
            ParseResponse("Friends", document);

            AddPath("getchampionranks", "ChampionRanks", "GetChampionRanks", document, ("player", typeof(string)));
            ParseResponse("ChampionRanks", document);

            AddPath("getchampions", "Champions", "GetChampions", document, ("languageCode", typeof(LanguageCode)));
            ParseResponse("Champions", document);

            AddPath("getchampionskins", "ChampionSkins", "GetChampionSkins", document, ("championId", typeof(int)),
                    ("languageCode", typeof(LanguageCode)));
            ParseResponse("ChampionSkins", document);

            AddPath("getitems", "Items", "GetItems", document, ("languageCode", typeof(LanguageCode)));
            ParseResponse("Items", document);

            AddPath("getmatchdetails", "MatchDetails", "GetMatchDetails", document, ("matchId", typeof(int)));
            ParseResponse("MatchDetails", document);

            AddPath("getmatchdetailsbatch", "MatchDetails", "GetMatchDetailsBatch", document, ("matchIds", typeof(int[])));
            ParseResponse("MatchDetailsBatch", document);

            // Only works for live matches
            AddPath("getmatchplayerdetails", "MatchPlayerDetails", "GetMatchPlayerDetails", document, ("matchId", typeof(int)));
            ParseResponse("MatchPlayerDetails", document);

            AddPath("getmatchidsbyqueue", "MatchIdsByQueue", "GetMatchIdsByQueue", document, ("queue", typeof(Queue)), ("date", typeof(string)),
                    ("hour", typeof(string)));
            ParseResponse("MatchIdsByQueue", document);

            AddPath("getleagueleaderboard", "LeagueLeaderBoard", "GetLeagueLeaderBoard", document, ("queue", typeof(Queue)),
                    ("tier", typeof(LeagueTier)), ("season", typeof(Season)));
            ParseResponse("LeagueLeaderBoard", document);

            AddPath("getmatchhistory", "MatchHistory", "GetMatchHistory", document, ("player", typeof(string)));
            ParseResponse("MatchHistory", document);

            AddPath("getplayer", "Player", "GetPlayer", document, ("player", typeof(string)));
            ParseResponse("Player", document);

            AddPath("getplayerloadouts", "PlayerLoadouts", "GetPlayerLoadouts", document, ("player", typeof(string)),
                    ("languageCode", typeof(LanguageCode)));
            ParseResponse("PlayerLoadouts", document);

            AddPath("getplayerstatus", "PlayerStatus", "GetPlayerStatus", document, ("player", typeof(string)));
            ParseResponse("PlayerStatus", document);

            AddPath("getqueuestats", "QueueStats", "GetQueueStats", document, ("player", typeof(string)), ("queue", typeof(Queue)));
            ParseResponse("QueueStats", document);

            AddPath("gettopmatches", "TopMatches", "GetTopMatches", document);
            ParseResponse("TopMatches", document);

            AddPath("getplayerachievements", "PlayerAchievements", "GetPlayerAchievements", document, ("player", typeof(string)));
            ParseResponse("PlayerAchievements", document);

            AddPath("getpatchinfo", "PatchInfo", "GetPatchInfo", document);
            ParseResponse("PatchInfo", document);

            AddPath("gethirezserverstatus", "HirezServerStatus", "GetHirezServerStatus", document);
            ParseResponse("HirezServerStatus", document);

            var swaggerOutputFilePath = Path.Combine(_jsonModelDirectory, "paladins-swagger.json");
            var documentAsStr = JsonConvert.SerializeObject(document, Formatting.Indented,
                                                            new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            using (var sw = new StreamWriter(swaggerOutputFilePath, false, Encoding.UTF8))
                sw.Write(documentAsStr);

            // Invoke AutoRest.exe to export swagger definition as *.cs Models
            var generatedModelsDirectory = Path.Combine(_jsonModelDirectory, "models");
            var autoRestArgs =
                $"-Input \"{swaggerOutputFilePath}\" -Namespace HiRezApi.Common.Models -OutputDirectory \"{generatedModelsDirectory}\" -AddCredentials true";

            var fullPath = Path.Combine(Environment.CurrentDirectory, "AutoRest\\AutoRest.exe");
            var psi = new ProcessStartInfo();
            psi.FileName = Path.GetFileName(fullPath);
            psi.WorkingDirectory = Path.GetDirectoryName(fullPath);
            psi.Arguments = autoRestArgs;
            Process.Start(psi);
        }

        private void AddPath(string pathName, string modelName, string operationId, SwaggerDocument document,
            params (string name, Type type)[] paramTuples)
        {
            var isArray = IsArrayResponse(modelName);

            var pathItem = new PathItem();
            pathItem.parameters = new List<Parameter>();
            pathItem.vendorExtensions = null;

            // Parameters
            foreach (var paramTuple in paramTuples)
            {
                var parameter = new Parameter();
                parameter.name = paramTuple.name;
                parameter.@in = "path";
                parameter.description = "The " + paramTuple.name;
                parameter.required = true;
                parameter.type = "string";
                pathItem.parameters.Add(parameter);
            }

            var operation = new Operation();
            operation.parameters = new List<Parameter>();
            operation.responses = new Dictionary<string, Response>();
            operation.operationId = operationId;
            operation.description = pathName;
            operation.produces = new List<string> {"application/json"};

            var response200 = new Response();
            response200.description = "Response";
            response200.schema = new Schema {@ref = "#/definitions/" + modelName + (isArray ? "Response" : "")};
            operation.responses.Add("200", response200);

            var responseDefault = new Response();
            responseDefault.description = "Unexpected Error";
            responseDefault.schema = new Schema {@ref = "#/definitions/ErrorModel"};
            operation.responses.Add("default", responseDefault);

            pathItem.get = operation;

            if (paramTuples.Length > 0)
            {
                var parameters = string.Join("/", paramTuples.Select(p => "{" + p.name + "}"));
                document.paths.Add("/" + pathName + "/" + parameters, pathItem);
            }
            else
            {
                document.paths.Add("/" + pathName, pathItem);
            }
        }

        private SwaggerDocument CreateDocBase()
        {
            var document = new SwaggerDocument();
            document.info = new Info();
            document.info.version = "0.5.8"; // 58 Open Beta
            document.info.title = "Paladins Api Client";
            document.info.description = "Paladins Api Client";
            document.info.termsOfService = "http://www.hirezstudios.com/wp-content/themes/hi-rez-studios/pdf/api-terms-of-use-agreement.pdf";
            document.info.contact = new Contact {email = "apugh@hirezstudios.com", name = "hirezstudios", url = "http://hirezstudios.com"};
            document.info.license = new License {name = "See ToS"};
            document.basePath = "/paladinsapi.svc";
            document.host = "api.paladins.com";
            document.schemes = new List<string> {"http"};
            document.consumes = new List<string> {"application/json"};
            document.produces = new List<string> {"application/json"};
            document.definitions = new Dictionary<string, Schema>();
            document.paths = new Dictionary<string, PathItem>();

            // Generic error model
            var errorDefinition = new Schema();
            errorDefinition.type = "object";
            errorDefinition.required = new List<string> {"ret_msg"};
            errorDefinition.properties = new Dictionary<string, Schema>();
            var messageProperty = new Schema();
            messageProperty.type = "string";
            errorDefinition.properties.Add("ret_msg", messageProperty);
            document.definitions.Add("ErrorModel", errorDefinition);

            // Base model
            var baseModelDefinition = new Schema();
            baseModelDefinition.type = "object";
            baseModelDefinition.required = new List<string> {"ret_msg"};
            baseModelDefinition.properties = new Dictionary<string, Schema>();
            var baseModelMessageProperty = new Schema();
            baseModelMessageProperty.type = "string";
            baseModelDefinition.properties.Add("ret_msg", baseModelMessageProperty);
            document.definitions.Add("BaseModel", baseModelDefinition);

            return document;
        }

        private Schema GetPropertyForSwagger(JToken token, JProperty jProperty)
        {
            var property = new Schema();

            if (token.Type == JTokenType.String)
            {
                property.type = "string";
                if (jProperty.Name.EndsWith("DateTime"))
                    property.format = "date";
            }

            if (token.Type == JTokenType.Integer)
                property.type = "integer";

            return property;
        }

        private bool IsArrayResponse(string definitionName)
        {
            var filePath = Path.Combine(_jsonModelDirectory, definitionName + ".json");
            string strJsonContent;
            using (var sr = new StreamReader(filePath, Encoding.UTF8)) strJsonContent = sr.ReadToEnd();

            try
            {
                JArray.Parse(strJsonContent);
                return true;
            }
            catch (JsonReaderException)
            {
                // Ignore
            }

            return false;
        }

        private void ParseResponse(string definitionName, SwaggerDocument document)
        {
            var filePath = Path.Combine(_jsonModelDirectory, definitionName + ".json");

            string strJsonContent;
            using (var sr = new StreamReader(filePath, Encoding.UTF8)) strJsonContent = sr.ReadToEnd();

            JArray jsonArr = null;
            JObject jsonObj = null;

            try
            {
                jsonArr = JArray.Parse(strJsonContent);

                if (jsonArr.Count < 1)
                {
                    Console.WriteLine("Array has no entries, skipping schema gen: " + definitionName);
                    return;
                }
            }
            catch (JsonReaderException)
            {
                jsonObj = JObject.Parse(strJsonContent);
            }

            var modelDefinition = new Schema();
            modelDefinition.properties = new Dictionary<string, Schema>();
            modelDefinition.type = "object";
            modelDefinition.allOf = new List<Schema> {new Schema {@ref = "#/definitions/BaseModel"}};

            var jToken = jsonArr == null ? jsonObj : jsonArr.First;

            foreach (var child in jToken.Children())
            {
                if (child.Type != JTokenType.Property)
                    throw new Exception("We do not support non properties yet at this level.");

                var jProperty = (JProperty) child;

                if (jProperty.Name == "ret_msg")
                    continue;

                if (child.First.Count() > 1)
                {
                    var modelDefinitionChild = new Schema();
                    modelDefinitionChild.properties = new Dictionary<string, Schema>();
                    modelDefinitionChild.type = "object";
                    modelDefinitionChild.allOf = new List<Schema>();

                    var childArr = child.First as JArray;

                    if (childArr != null)
                    {
                        modelDefinitionChild.type = "array";
                        modelDefinitionChild.items = new Schema {@ref = $"#/definitions/{definitionName}"};
                    }

                    var properties = childArr?.First.Children<JProperty>() ?? child.First.Children<JProperty>();

                    foreach (var childChild in properties)
                    {
                        var jPropertyChild = childChild;
                        var propertyChild = GetPropertyForSwagger(childChild.First, jPropertyChild);
                        if (jProperty.Name != jPropertyChild.Name)
                            modelDefinitionChild.properties.Add(jPropertyChild.Name, propertyChild);
                    }

                    // Prevent multiple models being created for Ability1, Ability2 etc.
                    if (jProperty.Name.StartsWith("Ability_"))
                    {
                        if (!document.definitions.ContainsKey("Ability"))
                            document.definitions.Add("Ability", modelDefinitionChild);
                    }
                    else
                    {
                        document.definitions.Add(jProperty.Name, modelDefinitionChild);
                    }
                }

                var property = GetPropertyForSwagger(child.First, jProperty);

                if (child.First.Count() > 1)
                    property.@ref = "#/definitions/" + jProperty.Name;

                // Prevent multiple models being created for Ability1, Ability2 etc.
                if (jProperty.Name.StartsWith("Ability_"))
                    property.@ref = "#/definitions/Ability";

                if (jProperty.Name.StartsWith("Ability_"))
                {
                    property.xname = jProperty.Name + "Def";
                    modelDefinition.properties.Add(jProperty.Name, property);
                }
                else
                {
                    modelDefinition.properties.Add(jProperty.Name, property);
                }
            }

            if (jsonArr != null)
            {
                var arrayDefinition = new Schema();
                arrayDefinition.type = "array";
                arrayDefinition.items = new Schema {@ref = $"#/definitions/{definitionName}"};
                document.definitions.Add(definitionName + "Response", arrayDefinition);
            }

            document.definitions.Add(definitionName, modelDefinition);
        }
    }
}