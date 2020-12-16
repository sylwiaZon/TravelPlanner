package com.travelplanner.ui.cityWalk

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.LinearLayout
import android.widget.RelativeLayout
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.floatingactionbutton.FloatingActionButton
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
        val adapter = CityWalkAdapter(travelId){
            viewModel.addToFavourites(it, travelId)
        }
        val floatingButton = v.findViewById<FloatingActionButton>(R.id.add_city_walk_floating_button)
        val savedWalks = v.findViewById<RelativeLayout>(R.id.saved_to_do)
        val noSavedWalks = v.findViewById<LinearLayout>(R.id.no_city_walks)
        savedWalks.visibility = View.GONE
        noSavedWalks.visibility = View.VISIBLE

        (childFragmentManager.findFragmentByTag("searchCityWalk") as SearchCityWalkFragment).setData(
                travelId!!, cityName!!
        )
        viewModel.liked.observe(viewLifecycleOwner, Observer {
            Toast.makeText(context, "Point added to list", Toast.LENGTH_SHORT).show()
        })
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.cityWalk.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty()) {
                adapter.setData(it)
                savedWalks.visibility = View.VISIBLE
                noSavedWalks.visibility = View.GONE
            }
        })

        floatingButton.setOnClickListener{
            val dialogView = inflater.inflate(R.layout.add_new_city_walk, container, false)
            val dialogViewTextInput = dialogView.findViewById<EditText>(R.id.city_walk_duration_input)
            AlertDialog.Builder(requireContext())
                    .setView(dialogView)
                    .setPositiveButton("Add") { _, _->
                        viewModel.getCityWalk(cityName, dialogViewTextInput.text.toString().toInt(), travelId)
                    }
                    .setNegativeButton("Cancel"){_,_ -> }
                    .show()
        }
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
        val EXTRA_CITY_NAME = "city_name"
    }
}