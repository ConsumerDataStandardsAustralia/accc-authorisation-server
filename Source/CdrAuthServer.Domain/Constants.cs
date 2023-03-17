﻿using System.Collections.Immutable;
using System.ComponentModel.Design;

namespace CdrAuthServer.Domain
{
    public static class Constants
    {
        public static class ClaimNames
        {
            public const string Confirmation = "cnf";
            public const string Scope = "scope";
            public const string JwksUri = "jwks_uri";
            public const string CdrArrangementId = "cdr_arrangement_id";
            public const string CdrArrangementVersion = "cdr_arrangement_version";
            public const string Expiry = "exp";
            public const string Active = "active";
            public const string ClientId = "client_id";
            public const string ClientAssertion = "client_assertion";
            public const string ClientAssertionType = "client_assertion_type";
            public const string GrantType = "grant_type";
            public const string AccountId = "account_id";
            public const string Acr = "acr";
            public const string JwtId = "jti";
            public const string SoftwareId = "software_id";
            public const string IdToken = "id_token";
            public const string AccessToken = "access_token";
            public const string RefreshToken = "refresh_token";
            public const string Request = "request";
            public const string RequestUri = "request_uri";
            public const string RedirectUri = "redirect_uri";
            public const string ResponseType = "response_type";
            public const string ResponseMode = "response_mode";
            public const string State = "state";
            public const string Nonce = "nonce";
            public const string Code = "code";
            public const string CodeChallenge = "code_challenge";
            public const string CodeChallengeMethod = "code_challenge_method";
            public const string CodeVerifier = "code_verifier";
            public const string Claims = "claims";
            public const string SharingDuration = "sharing_duration";
            public const string IssuedAt = "iat";
            public const string Expiration = "exp";
            public const string Audience = "aud";
            public const string NotBefore = "nbf";
            public const string Issuer = "iss";
            public const string Subject = "sub";
            public const string TokenType = "token_type";
            public const string ExpiresIn = "expires_in";
            public const string Name = "name";
            public const string FamilyName = "family_name";
            public const string GivenName = "given_name";
            public const string SectorIdentifierUri = "sector_identifier_uri";
            public const string AccessTokenHash = "at_hash";
            public const string AuthorizationCodeHash = "c_hash";
            public const string AuthorizationCode = "code";
            public const string StateHash = "s_hash";
            public const string Error = "error";
            public const string ErrorDescription = "error_description";
            public const string AuthTime = "auth_time";
            public const string UpdatedAt = "updated_at";            
        }

        public static class TokenTypes
        {
            public const string AccessToken = "at+jwt";
            public const string Jwt = "JWT";
            public const string IdToken = "JWT";
        }

        public static class Algorithms
        {
            public const string None = "none";

            public static class Signing
            {
                public const string ES256 = "ES256";
                public const string PS256 = "PS256";
            }

            public static class Jwe
            {
                public static class Alg
                {
                    public const string RSAOAEP = "RSA-OAEP";
                    public const string RSAOAEP256 = "RSA-OAEP-256";
                }

                public static class Enc
                {
                    public const string A128GCM = "A128GCM";
                    public const string A192GCM = "A192GCM";
                    public const string A256GCM = "A256GCM";
                    public const string A128CBCHS256 = "A128CBC-HS256";
                    public const string A192CBCHS384 = "A192CBC-HS384";
                    public const string A256CBCHS512 = "A256CBC-HS512";
                }
            }
        }

        public static class ClientMetadata
        {
            public const string RedirectUris = "redirect_uris";
            public const string TokenEndpointAuthMethod = "token_endpoint_auth_method";
            public const string TokenEndpointAuthSigningAlg = "token_endpoint_auth_signing_alg";
            public const string GrantTypes = "grant_types";
            public const string ResponseTypes = "response_types";
            public const string ApplicationType = "application_type";
            public const string IdTokenSignedResponseAlg = "id_token_signed_response_alg";
            public const string IdTokenEncryptedResponseAlg = "id_token_encrypted_response_alg";
            public const string IdTokenEncryptedResponseEnc = "id_token_encrypted_response_enc";
            public const string RequestObjectSigningAlg = "request_object_signing_alg";
            public const string SoftwareStatement = "software_statement";
            public const string AuthorizationSignedResponseAlg = "authorization_signed_response_alg";
            public const string AuthorizationEncryptedResponseAlg = "authorization_encrypted_response_alg";
            public const string AuthorizationEncryptedResponseEnc = "authorization_encrypted_response_enc";
        }

        public static class CodeChallengeMethods
        {
            public const string S256 = "S256";
        }
                
        public static class ErrorCodes
        {
            public const string UnsupportedGrantType = "unsupported_grant_type";
            public const string InvalidClient = "invalid_client";
            public const string InvalidRequest = "invalid_request";
            public const string InvalidRequestUri = "invalid_request_uri";
            public const string InvalidGrant = "invalid_grant";
            public const string AccessDenied = "access_denied";
            public const string InvalidRequestObject = "invalid_request_object";
            public const string MissingRequiredField = "urn:au-cds:error:cds-all:Field/Missing";
            public const string InvalidField = "urn:au-cds:error:cds-all:Field/Invalid";
            public const string InvalidConsentArrangement = "urn:au-cds:error:cds-all:Authorisation/InvalidArrangement";
            public const string UnexpectedError = "urn:au-cds:error:cds-all:GeneralError/Unexpected";
            public const string AdrStatusNotActive = "urn:au-cds:error:cds-all:Authorisation/AdrStatusNotActive";
            public const string UnauthorizedClient = "unauthorized_client";
            public const string UnsupportedResponseType = "unsupported_response_type";
            public const string InvalidScope = "invalid_scope";
            public const string InvalidRedirectUri = "invalid_redirect_uri";
            public const string InvalidClientMetadata = "invalid_client_metadata";
            public const string InvalidSoftwareStatement = "invalid_software_statement";
            public const string UnapprovedSoftwareStatement = "unapproved_software_statement";
        }

        public static class ValidationErrorMessages
        {
            public const string MissingClaim = "The '{0}' claim is missing.";
            public const string MustEqual = "The '{0}' claim value must be set to '{1}'.";
            public const string MustBeOne = "The '{0}' claim value must be one of '{1}'.";
            public const string MustContain = "The '{0}' claim value must contain the '{1}' value.";
            public const string InvalidRedirectUri = "One or more redirect uri is invalid";
        }

        public static class GrantTypes
        {
            public const string CdrArrangement = "cdr_arrangement";
            public const string RefreshToken = "refresh_token";
            public const string AuthCode = "authorization_code";
            public const string ClientCredentials = "client_credentials";
            public const string Hybrid = "hybrid";
            public const string RequestUri = "request_uri";
        }

        public static class ResponseModes
        {
            public const string FormPost = "form_post";
            public const string Fragment = "fragment";
            public const string FormPostJwt = "form_post.jwt";
            public const string FragmentJwt = "fragment.jwt";
            public const string QueryJwt = "query.jwt";
            public const string Jwt = "jwt";
        }

        public static class ResponseTypes
        {
            public const string AuthCode = "code";
            public const string Hybrid = "code id_token";
        }

        // The order of the response modes represents the precedence for each response type.
        public static readonly ImmutableDictionary<string, string[]> SupportedResponseModesForResponseType = new Dictionary<string, string[]>
        {
            { ResponseTypes.Hybrid, new string[] { ResponseModes.Fragment, ResponseModes.FormPost } },
            { ResponseTypes.AuthCode, new string[] { ResponseModes.QueryJwt, ResponseModes.FragmentJwt, ResponseModes.FormPostJwt, ResponseModes.Jwt } },
        }.ToImmutableDictionary();

        public static class ValidationRestrictions
        {
            public static class InputLengthRestrictions
            {
                public const int ScopeMaxLength = 1000;

                // Using the same values as code verifier.  Not necessarily correct
                // as the value will be a SHA256 string (64 chars) but is also base64 url encoded.
                public const int CodeChallengeMinLength = 43;
                public const int CodeChallengeMaxLength = 128;

                public const int CodeVerifierMinLength = 43;
                public const int CodeVerifierMaxLength = 128;
            }
        }

        public static class Scopes
        {
            public const string OpenId = "openid";
            public const string Profile = "profile";
            public const string Registration = "cdr:registration";
            public const string Common = "common:customer.basic:read common:customer.detail:read";
            public const string Banking = "bank:accounts.basic:read bank:accounts.detail:read bank:transactions:read bank:payees:read bank:regular_payments:read";
            public const string Energy = "energy:electricity.servicepoints.basic:read energy:electricity.servicepoints.detail:read energy:electricity.usage:read energy:electricity.der:read energy:accounts.basic:read energy:accounts.detail:read energy:accounts.paymentschedule:read energy:accounts.concessions:read energy:billing:read";
            public const string AdminMetadataUpdate = "admin:metadata:update";
            public const string BankingSectorScopes = $"{OpenId} {Profile} {Registration} {Common} {Banking}";
            public const string AllSectorScopes = $"{BankingSectorScopes} {Energy}";

            public static class ResourceApis
            {
                public static class Common
                {
                    public const string CustomerBasicRead = "common:customer.basic:read";
                }

                public static class Banking
                {
                    public const string AccountsBasicRead = "bank:accounts.basic:read";
                }
            }            
        }

        public static class EntityStatus
        {
            public const string Active = "ACTIVE";
            public const string InActive = "INACTIVE";
            public const string Removed = "REMOVED";
        }
    }
}
