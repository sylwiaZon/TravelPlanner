package com.travelplanner.utils

import io.reactivex.Single
import io.reactivex.schedulers.Schedulers

fun <T> Single<T>.applySchedulers(): Single<T> {
    return this.subscribeOn(Schedulers.trampoline())
        .observeOn(Schedulers.trampoline())
}

fun <T> Single<T>.applySchedulers(schedulers: RxSchedulers): Single<T> {
    return this.subscribeOn(schedulers.io())
        .observeOn(schedulers.uiThread())
}