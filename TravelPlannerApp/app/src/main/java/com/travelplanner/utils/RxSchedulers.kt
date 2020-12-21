package com.travelplanner.utils

import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers

open class RxSchedulers  {
    open fun io() = Schedulers.io()
    open fun uiThread() = AndroidSchedulers.mainThread()
}