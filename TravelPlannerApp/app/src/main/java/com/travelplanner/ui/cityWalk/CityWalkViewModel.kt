package com.travelplanner.ui.cityWalk

import android.util.Log
import android.widget.Toast
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.travelplanner.api.applySchedulers
import com.travelplanner.di.DIContainer
import com.travelplanner.models.CityWalk

class CityWalkViewModel : ViewModel() {
    private val travelApiService = DIContainer.travelApiService
    private val cityWalkApiService = DIContainer.cityWalkApiService
    private val _cityWalk = MutableLiveData<List<CityWalk>>()
    val cityWalk: LiveData<List<CityWalk>> = _cityWalk
    private val _liked = MutableLiveData<Boolean>()
    val liked: LiveData<Boolean> = _liked
    private val _added = MutableLiveData<String>()
    val added: LiveData<String> = _added

    fun setTravelId(travelId: String){
        travelApiService.getCityWalk(travelId)
                .applySchedulers()
                .subscribe ({ t ->
                    _cityWalk.value = t
                }, {
                    Log.e("ToSeeListViewModel", it.message.toString())
                })
    }

    fun addToFavourites(poiId: String?, travelId: String?){
        if(poiId == null || travelId == null ) return
        DIContainer.travelApiService.postToSeeItem(poiId, travelId)
            .applySchedulers()
            .subscribe ({
                _liked.value = true
            },{
                Log.e("ToSeeListViewModel", it.message.toString())
            })
    }

    fun getCityWalk(cityName: String, duration: Int, travelId: String){
        cityWalkApiService.getCityWalks(cityName, duration)
                .applySchedulers()
                .subscribe({
                    if(it.any())
                        addCityWalk(it.first(), travelId)
                },{
                    Log.e("ToSeeListViewModel", it.message.toString())
                })
    }

    fun addCityWalk(cityWalk: CityWalk, travelId: String){
        travelApiService.postCityWalk(cityWalk, travelId)
                .applySchedulers()
                .subscribe({
                    _added.value = it.body()
                    setTravelId(travelId)
                },{
                    Log.e("ToSeeListViewModel", it.message.toString())
                })
    }
}