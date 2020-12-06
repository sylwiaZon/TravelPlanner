package com.travelplanner.ui.allTravels

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.travelplanner.R
import com.travelplanner.ui.travel.TravelFragment
import com.travelplanner.ui.travelDetails.TravelDetailsActivity

class AllTravelsFragment : Fragment() {

    private lateinit var allTravelsViewModel: AllTravelsViewModel
    private lateinit var recyclerView: RecyclerView

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        allTravelsViewModel =
                ViewModelProvider(this).get(AllTravelsViewModel::class.java)
        val root = inflater.inflate(R.layout.fragment_all_travels, container, false)
        val adapter = AllTravelsAdapter {
            val intent = Intent(activity, TravelDetailsActivity::class.java)
            intent.putExtra(TravelFragment.EXTRA_TRAVEL, it)
            activity?.startActivity(intent)
        }
        recyclerView = root.findViewById(R.id.all_travels_recycler)
        recyclerView.layoutManager = LinearLayoutManager(context)
        recyclerView.adapter = adapter
        allTravelsViewModel.travelsList.observe(viewLifecycleOwner, Observer {
            adapter.setData(it)
        })
        return root
    }
}