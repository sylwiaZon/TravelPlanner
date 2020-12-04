package com.travelplanner.api.interceptors

import okhttp3.Interceptor
import okhttp3.Request
import okhttp3.Response

class DefaultHeadersInterceptor : Interceptor {
    override fun intercept(chain: Interceptor.Chain): Response {
        val original = chain.request();
        val request: Request = original.newBuilder()
                .header("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJNYWlsIjoiTWFpbCIsIm5iZiI6MTYwNzAyODI5MiwiZXhwIjoxNjA3NjMzMDkyLCJpYXQiOjE2MDcwMjgyOTJ9.ROTmf-5tdyz6qb1WxVxSa19LqaeeNyLIOK6qFEKY3wE")
                .header("Content-Type", "application/json")
                .method(original.method(), original.body())
                .build()

        return chain.proceed(request)
    }

}