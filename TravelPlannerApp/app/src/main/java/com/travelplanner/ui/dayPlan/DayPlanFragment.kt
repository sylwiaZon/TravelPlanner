package com.travelplanner.ui.dayPlan

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R

class  DayPlanFragment : Fragment() {

    lateinit var viewModel: DayPlanViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_day_plan, container, false)
        viewModel =
            ViewModelProvider(this).get(DayPlanViewModel::class.java)
        var travelId = activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)
        travelId?.let {
            viewModel.setTravelId(it)
        }

        val noSavedPlan = v.findViewById<LinearLayout>(R.id.no_saved_day_plan)
        val

        val recycler = v.findViewById<RecyclerView>(R.id.day_plan_recycler)
        recycler.visibility = View.GONE
        val adapter = DayPlanAdapter(travelId){
            viewModel.addToFavourites(it, travelId)
        }
        viewModel.liked.observe(viewLifecycleOwner, Observer {
            Toast.makeText(context, "Point added to list", Toast.LENGTH_SHORT).show()
        })
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.dayPlan.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty()){
                adapter.setData(it.first().days)
                noSavedPlan.visibility = View.GONE
                recycler.visibility = View.VISIBLE
            }
        })
        return v
    }

    companion object{
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}