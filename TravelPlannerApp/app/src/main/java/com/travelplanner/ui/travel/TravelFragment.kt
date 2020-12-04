package com.travelplanner.ui.travel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.models.Travel

class TravelFragment : TravelFragmentBase() {

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = super.onCreateView(inflater, container, savedInstanceState)
        (travelViewModel as TravelViewModel)
                .setTravel(activity?.intent?.getParcelableExtra<Travel>(EXTRA_TRAVEL))
        return v
    }

    override fun getViewModel(): TravelViewModelBase {
        return ViewModelProvider(this).get(TravelViewModel::class.java)
    }

    companion object {
        const val EXTRA_TRAVEL = "travel"
    }
}