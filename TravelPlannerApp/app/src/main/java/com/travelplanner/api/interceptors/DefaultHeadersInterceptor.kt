package com.travelplanner.api.interceptors

import okhttp3.Interceptor
import okhttp3.Request
import okhttp3.Response

class DefaultHeadersInterceptor : Interceptor {
    override fun intercept(chain: Interceptor.Chain): Response {
        val original = chain.request();
        val request: Request = original.newBuilder()
                .header("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJNYWlsIjoibWFpbEBtaWwuY29tIiwibmJmIjoxNjA4MjM1MzY0LCJleHAiOjE2MDg4NDAxNjQsImlhdCI6MTYwODIzNTM2NH0.1VeptuYRA3mRHmOBoPhlNYYNfXWlU3mUe38cpnGnTyg")
                .header("Content-Type", "application/json")
                .method(original.method(), original.body())
                .build()

        return chain.proceed(request)
    }

}