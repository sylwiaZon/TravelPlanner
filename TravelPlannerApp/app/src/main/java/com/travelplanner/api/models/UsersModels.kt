package com.travelplanner.api.models

object Authorize{
    data class Request(val email: String, val password: String)
    data class Response(val token: String)
}