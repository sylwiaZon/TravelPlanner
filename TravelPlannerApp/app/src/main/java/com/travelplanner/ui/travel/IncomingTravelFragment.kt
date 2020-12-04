package com.travelplanner.ui.travel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.observe
import com.travelplanner.R

class IncomingTravelFragment : TravelFragmentBase() {
    override fun getViewModel(): TravelViewModelBase {
        return ViewModelProvider(this).get(IncomingTravelViewModel::class.java)
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = super.onCreateView(inflater, container, savedInstanceState)
        val noIncTravel = view?.findViewById<ConstraintLayout>(R.id.no_incoming_travel)
        val incTravel = view?.findViewById<LinearLayout>(R.id.incoming_travel)
        val incomingTravelViewModel = travelViewModel as IncomingTravelViewModel
        incTravel?.visibility = View.GONE
        noIncTravel?.visibility = View.GONE
        incomingTravelViewModel.isNewTravelScreen.observe(viewLifecycleOwner) {
            if (it) {
                incTravel?.visibility = View.GONE
                noIncTravel?.visibility = View.VISIBLE
            } else{
                incTravel?.visibility = View.VISIBLE
                noIncTravel?.visibility = View.GONE
            }
        }
        return view
    }
}