package com.travelplanner.ui.travel

import androidx.lifecycle.MutableLiveData
import com.travelplanner.models.Travel
import io.reactivex.Observable
import io.reactivex.subjects.PublishSubject

class TravelViewModel : TravelViewModelBase() {
    private val subject: PublishSubject<Travel?> = PublishSubject.create()

    fun setTravel(value: Travel?) {
        value?.let {
            subject.onNext(it)
        }
    }

    override fun loadTravel(): Observable<Travel?> = subject
}