package com.travelplanner.ui.flight

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.ui.dayPlan.DayPlanAdapter
import com.travelplanner.ui.dayPlan.DayPlanViewModel

class FlightFragment : Fragment() {
    lateinit var viewModel: FlightViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_flight, container, false)
        viewModel =
                ViewModelProvider(this).get(FlightViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        /*val toFlight = v.findViewById<RecyclerView>(R.id.to_flight)
        val toFlight = v.findViewById<RecyclerView>(R.id.to_flight)
        val adapter = DayPlanAdapter(context)
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.dayPlan.observe(viewLifecycleOwner, Observer {
            adapter.setData(it)
        })*/
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}