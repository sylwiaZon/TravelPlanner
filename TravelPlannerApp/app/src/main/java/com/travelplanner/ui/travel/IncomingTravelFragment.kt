package com.travelplanner.ui.travel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.LinearLayout
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentTransaction
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.observe
import androidx.navigation.Navigation
import androidx.navigation.findNavController
import com.travelplanner.R
import com.travelplanner.ui.newTravel.NewTravelFragment


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
        val addTravelButton = noIncTravel?.findViewById<Button>(R.id.incoming_travel_add_new_travel)
        addTravelButton?.setOnClickListener {
            changeFragment()
        }
        return view
    }

    private fun changeFragment() {
        Navigation.findNavController(requireActivity(), R.id.nav_host_fragment).navigate(R.id.nav_add_travel)
    }
}