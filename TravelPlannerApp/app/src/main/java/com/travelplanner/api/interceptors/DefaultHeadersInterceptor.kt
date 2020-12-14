package com.travelplanner.api.interceptors

import okhttp3.Interceptor
import okhttp3.Request
import okhttp3.Response

class DefaultHeadersInterceptor : Interceptor {
    override fun intercept(chain: Interceptor.Chain): Response {
        val original = chain.request();
        val request: Request = original.newBuilder()
                .header("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJNYWlsIjoiTWFpbCIsIm5iZiI6MTYwNzk3Mzc1NSwiZXhwIjoxNjA4NTc4NTU1LCJpYXQiOjE2MDc5NzM3NTV9.3Z7SYUBstjLwizc2ZuIK4UU9r-tlmZBuOU0qdItEHsg")
                .header("Content-Type", "application/json")
                .method(original.method(), original.body())
                .build()

        return chain.proceed(request)
    }

}