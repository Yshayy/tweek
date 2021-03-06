namespace Tweek.Publishing.Service.Validation
{
    public static class Patterns
    {
        public static readonly string Manifests = "^manifests/.*\\.json$";
        public static readonly string JPad = "^implementations/jpad/.*\\.jpad$";
        public static readonly string ExternalApp = "^external_apps/(.+)\\.json$";
        public static readonly string Policy = "^security/policy.json$";
        public static readonly string SubjectExtractionRules = "^security/subject_extraction_rules.rego$";
    }
}