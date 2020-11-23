package com.travelplanner.api.interceptors

import okhttp3.Interceptor
import okhttp3.Request
import okhttp3.Response

class DefaultHeadersInterceptor : Interceptor {
    override fun intercept(chain: Interceptor.Chain): Response {
        val original = chain.request();
        val request: Request = original.newBuilder()
                .header("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJNYWlsIjoiTWFpbGVrIiwibmJmIjoxNjA2MTU5NzM4LCJleHAiOjE2MDY3NjQ1MzgsImlhdCI6MTYwNjE1OTczOH0.v3zOQFSe1KQP-NZnz1n3nEDPadkIJzebqQuuX3TddaM")
                .header("Content-Type", "application/json")
                .method(original.method(), original.body())
                .build()

        return chain.proceed(request)
    }

}