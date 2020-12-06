package com.travelplanner.ui.flight

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentContainerView
import androidx.fragment.app.findFragment
import androidx.lifecycle.LifecycleOwner
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.observe
import androidx.viewpager2.adapter.FragmentViewHolder
import com.travelplanner.R

class FlightFragment : Fragment() {
    lateinit var viewModel: FlightViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_flight, container, false)
        viewModel =
                ViewModelProvider(this).get(FlightViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        viewModel.toFlight.observe(viewLifecycleOwner){
            (childFragmentManager.findFragmentByTag("toFlightFragment") as SingleFlightFragment).setFlight(it)
        }
        viewModel.fromFlight.observe(viewLifecycleOwner){
            (childFragmentManager.findFragmentByTag("fromFlightFragment") as SingleFlightFragment).setFlight(it)
        }
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}