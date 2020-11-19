package com.travelplanner.ui.travel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

class TravelViewModel : ViewModel() {

    private val _text = MutableLiveData<String>().apply {
        value = "This is Travel Fragment"
    }
    val text: LiveData<String> = _text
}