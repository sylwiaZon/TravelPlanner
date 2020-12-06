package com.travelplanner.ui.hotel

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.Hotel
import com.travelplanner.models.HotelWithDetails
import com.travelplanner.models.Itinerary


class HotelViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val _hotel = MutableLiveData<HotelWithDetails>()
    val hotel: LiveData<HotelWithDetails> = _hotel

    fun setTravelId(travelId: String){
        travelApiService.getHotel(travelId)
                .applySchedulers()
                .subscribe({ t ->
                    _hotel.value = t
                }, {
                    Log.e("HotelViewModel",it.message.toString())
                })
    }
}