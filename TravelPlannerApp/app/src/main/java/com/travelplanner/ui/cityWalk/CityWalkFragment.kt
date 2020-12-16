package com.travelplanner.ui.cityWalk

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.ui.dayPlan.DayPlanAdapter
import com.travelplanner.ui.dayPlan.DayPlanViewModel
import com.travelplanner.ui.flight.SingleFlightFragment

class CityWalkFragment : Fragment() {

    lateinit var viewModel: CityWalkViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_city_walk, container, false)
        viewModel =
                ViewModelProvider(this).get(CityWalkViewModel::class.java)
        val travelId = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        val cityName = activity?.intent?.getStringExtra(EXTRA_CITY_NAME)
        travelId?.let {
            viewModel.setTravelId(travelId)
        }
        val recycler = v.findViewById<RecyclerView>(R.id.city_walk_recycler)
        val savedWalks = v.findViewById<RecyclerView>(R.id.saved_to_do)
        savedWalks.visibility = View.GONE
        val noSavedWalks = v.findViewById<RecyclerView>(R.id.no_city_walks_view)
        noSavedWalks.visibility = View.VISIBLE
        val adapter = CityWalkAdapter(travelId){
            viewModel.addToFavourites(it, travelId)
        }
        (childFragmentManager.findFragmentByTag("searchCityWalk") as SearchCityWalkFragment).setData(
                travelId!!, cityName!!
        )
        viewModel.liked.observe(viewLifecycleOwner, Observer {
            Toast.makeText(context, "Point added to list", Toast.LENGTH_SHORT).show()
        })
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.cityWalk.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty())
                adapter.setData(it)
            savedWalks.visibility = View.VISIBLE
            noSavedWalks.visibility = View.GONE
        })
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
        val EXTRA_CITY_NAME = "city_name"
    }
}