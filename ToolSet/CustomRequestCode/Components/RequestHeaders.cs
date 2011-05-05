using System;
using System.Collections.Generic;
using System.Text;

namespace usertools.CustomRequest
{
    public enum RequestHeaders
    {
        // Summary:
        //     The Cache-Control header, which specifies directives that must be obeyed
        //     by all cache control mechanisms along the request/response chain.
        CacheControl = 0,
        //
        // Summary:
        //     The Connection header, which specifies options that are desired for a particular
        //     connection.
        KeepAlive = 1,
        //
        // Summary:
        //     The Pragma header, which specifies implementation-specific directives that
        //     might apply to any agent along the request/response chain.
        Pragma = 2,
        //
        // Summary:
        //     The Trailer header, which specifies the header fields present in the trailer
        //     of a message encoded with chunked transfer-coding.
        Trailer = 3,
        //
        // Summary:
        //     The Transfer-Encoding header, which specifies what (if any) type of transformation
        //     that has been applied to the message body.
        TransferEncoding = 4,
        //
        // Summary:
        //     The Upgrade header, which specifies additional communications protocols that
        //     the client supports.
        Upgrade = 5,
        //
        // Summary:
        //     The Via header, which specifies intermediate protocols to be used by gateway
        //     and proxy agents.
        Via = 6,
        //
        // Summary:
        //     The Warning header, which specifies additional information about that status
        //     or transformation of a message that might not be reflected in the message.
        Warning = 7,
        //
        // Summary:
        //     The Allow header, which specifies the set of HTTP methods supported.
        Allow = 8,
        //
        // Summary:
        //     The Content-Length header, which specifies the length, in bytes, of the accompanying
        //     body data.
        ContentLength = 9,
        //
        // Summary:
        //     The Content-Type header, which specifies the MIME type of the accompanying
        //     body data.
        ContentType = 10,
        //
        // Summary:
        //     The Content-Encoding header, which specifies the encodings that have been
        //     applied to the accompanying body data.
        ContentEncoding = 11,
        //
        // Summary:
        //     The Content-Langauge header, which specifies the natural language(s) of the
        //     accompanying body data.
        ContentLanguage = 12,
        //
        // Summary:
        //     The Content-Location header, which specifies a URI from which the accompanying
        //     body may be obtained.
        ContentLocation = 13,
        //
        // Summary:
        //     The Content-MD5 header, which specifies the MD5 digest of the accompanying
        //     body data, for the purpose of providing an end-to-end message integrity check.
        ContentMd5 = 14,
        //
        // Summary:
        //     The Content-Range header, which specifies where in the full body the accompanying
        //     partial body data should be applied.
        ContentRange = 15,
        //
        // Summary:
        //     The Expires header, which specifies the date and time after which the accompanying
        //     body data should be considered stale.
        Expires = 16,
        //
        // Summary:
        //     The Last-Modified header, which specifies the date and time at which the
        //     accompanying body data was last modified.
        LastModified = 17,
        //
        // Summary:
        //     The Accept header, which specifies the MIME types that are acceptable for
        //     the response.
        AcceptCharset = 18,
        //
        // Summary:
        //     The Accept-Encoding header, which specifies the content encodings that are
        //     acceptable for the response.
        AcceptEncoding = 19,
        //
        // Summary:
        //     The Accept-Langauge header, which specifies that natural languages that are
        //     preferred for the response.
        AcceptLanguage = 20,
        //
        // Summary:
        //     The Authorization header, which specifies the credentials that the client
        //     presents in order to authenticate itself to the server.
        Authorization = 21,
        //
        // Summary:
        //     The Cookie header, which specifies cookie data presented to the server.
        Cookie = 22,
        //
        // Summary:
        //     The From header, which specifies an Internet E-mail address for the human
        //     user who controls the requesting user agent.
        From = 23,
        //
        // Summary:
        //     The Host header, which specifies the host name and port number of the resource
        //     being requested.
        IfMatch = 24,
        //
        // Summary:
        //     The If-Modified-Since header, which specifies that the requested operation
        //     should be performed only if the requested resource has been modified since
        //     the indicated data and time.
        IfModifiedSince = 25,
        //
        // Summary:
        //     The If-None-Match header, which specifies that the requested operation should
        //     be performed only if none of client's cached copies of the indicated resources
        //     are current.
        IfNoneMatch = 26,
        //
        // Summary:
        //     The If-Range header, which specifies that only the specified range of the
        //     requested resource should be sent, if the client's cached copy is current.
        IfRange = 27,
        //
        // Summary:
        //     The If-Unmodified-Since header, which specifies that the requested operation
        //     should be performed only if the requested resource has not been modified
        //     since the indicated date and time.
        IfUnmodifiedSince = 27,
        //
        // Summary:
        //     The Max-Forwards header, which specifies an integer indicating the remaining
        //     number of times that this request may be forwarded.
        MaxForwards = 28,
        //
        // Summary:
        //     The Proxy-Authorization header, which specifies the credentials that the
        //     client presents in order to authenticate itself to a proxy.
        ProxyAuthorization = 29,
        //
        // Summary:
        //     The TE header, which specifies the transfer encodings that are acceptable
        //     for the response.
        Te = 30,
        //
        // Summary:
        //     The Translate header, a Microsoft extension to the HTTP specification used
        //     in conjunction with WebDAV functionality.
        Translate = 31,
        //
        // Summary:
        //     The User-Agent header, which specifies information about the client agent.
        UserAgent = 32,
    }
}
